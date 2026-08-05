using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Rocket.Core.Plugins;
using Tavstal.RocketFlow.Attributes;

namespace Tavstal.RocketFlow.Core
{
    public static class EventManager
    {
        private static readonly ConcurrentDictionary<Type, List<EventSubscription>> _subscriptions
            = new ConcurrentDictionary<Type, List<EventSubscription>>();
 
        private static readonly object _lock = new object();

        public static void RegisterAll(RocketPlugin plugin)
        {
            var types = plugin.GetType().Assembly.GetTypes();
            foreach (var type in types)
            {
                if (!type.GetInterfaces().Contains(typeof(EventListener)))
                    continue;
                RegisterAll(Activator.CreateInstance(type));
            }
        }
        
        public static void RegisterAll(object listenerInstance)
        {
            if (listenerInstance == null) throw new ArgumentNullException(nameof(listenerInstance));
 
            var type = listenerInstance.GetType();
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
 
            foreach (var method in methods)
            {
                var attr = method.GetCustomAttribute<EventHandlerAttribute>();
                if (attr == null) continue;
 
                var parameters = method.GetParameters();
                if (parameters.Length != 1 || !typeof(Event).IsAssignableFrom(parameters[0].ParameterType))
                {
                    throw new InvalidOperationException(
                        $"'{type.FullName}.{method.Name}' has [EventListener] but must take exactly one parameter derived from Event.");
                }
 
                var eventType = parameters[0].ParameterType;
                var invoker = BuildInvoker(method, eventType);
                var target = method.IsStatic ? null : listenerInstance;
                if (target == null)
                    continue;
                
                var subscription = new EventSubscription(target, method, attr.Priority, attr.IgnoreCancelled, invoker);
 
                lock (_lock)
                {
                    var list = _subscriptions.GetOrAdd(eventType, _ => new List<EventSubscription>());
                    list.Add(subscription);
                    list.Sort((a, b) => a.Priority.CompareTo(b.Priority));
                }
            }
        }
        
        public static void UnregisterAll(object? listenerInstance)
        {
            if (listenerInstance == null) return;
 
            lock (_lock)
            {
                foreach (var list in _subscriptions.Values)
                    list.RemoveAll(s => ReferenceEquals(s.Target, listenerInstance));
            }
        }
        public static void UnregisterAssembly(Assembly? assembly)
        {
            if (assembly == null) return;
 
            lock (_lock)
            {
                foreach (var list in _subscriptions.Values)
                    list.RemoveAll(s => s.OwningAssembly == assembly);
            }
        }
        
        public static TEvent Fire<TEvent>(TEvent e) where TEvent : Event
        {
            if (e == null) 
                throw new ArgumentNullException(nameof(e));
 
            var cancellable = e as ICancellable;
 
            foreach (var type in GetTypeHierarchy(e.GetType()))
            {
                if (!_subscriptions.TryGetValue(type, out var list)) continue;
 
                EventSubscription[] snapshot;
                lock (_lock) snapshot = list.ToArray();
 
                foreach (var sub in snapshot)
                {
                    if (cancellable is { IsCancelled: true } && !sub.IgnoreCancelled)
                        continue;
 
                    sub.Invoke(e);
                }
            }
 
            return e;
        }
 
        private static IEnumerable<Type> GetTypeHierarchy(Type? type)
        {
            while (type != null && typeof(Event).IsAssignableFrom(type))
            {
                yield return type;
                type = type.BaseType;
            }
        }
        
        private static Action<object, Event> BuildInvoker(MethodInfo method, Type eventType)
        {
            var targetParam = Expression.Parameter(typeof(object), "target");
            var eventParam = Expression.Parameter(typeof(Event), "evt");
            var castEvent = Expression.Convert(eventParam, eventType);
 
            Expression call = method.IsStatic
                ? Expression.Call(method, castEvent)
                : Expression.Call(Expression.Convert(targetParam, method.DeclaringType!), method, castEvent);
 
            return Expression.Lambda<Action<object, Event>>(call, targetParam, eventParam).Compile();
        }
    }

}