using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Lighting
{
    public class LightMoonEvent : Event
    {
        public bool IsFullMoon { get; }

        public LightMoonEvent(bool isFullMoon)
        {
            IsFullMoon = isFullMoon;
        }
    }
}