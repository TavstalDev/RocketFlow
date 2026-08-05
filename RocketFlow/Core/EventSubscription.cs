using System;
using System.Reflection;

namespace Tavstal.RocketFlow.Core
{
    internal sealed class EventSubscription
    {
        public object Target { get; }
        public MethodInfo Method { get; }
        public EEventPriority Priority { get; }
        public bool IgnoreCancelled { get; }
        public Assembly OwningAssembly { get; }
 
        private readonly Action<object, Event> _invoker;
 
        public EventSubscription(object target, MethodInfo method, EEventPriority priority, bool ignoreCancelled, Action<object, Event> invoker)
        {
            Target = target;
            Method = method;
            Priority = priority;
            IgnoreCancelled = ignoreCancelled;
            OwningAssembly = method.DeclaringType?.Assembly!;
            _invoker = invoker;
        }
 
        public void Invoke(Event e) => _invoker(Target, e);
    }

}