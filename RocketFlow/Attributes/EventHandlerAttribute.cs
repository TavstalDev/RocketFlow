using System;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class EventHandlerAttribute : Attribute
    {
        public EEventPriority Priority { get; }
        
        public bool IgnoreCancelled { get; }
 
        public EventHandlerAttribute(EEventPriority priority = EEventPriority.NORMAL, bool ignoreCancelled = false)
        {
            Priority = priority;
            IgnoreCancelled = ignoreCancelled;
        }
    }

}