using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Lighting
{
    public class LightDayNightEvent : Event
    {
        public bool IsDay { get; }
        
        public LightDayNightEvent(bool isDay)
        {
            IsDay = isDay;
        }
    }
}