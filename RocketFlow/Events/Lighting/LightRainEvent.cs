using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Lighting
{
    public class LightRainEvent : Event
    {
        public ELightingRain Rain { get;  }

        public LightRainEvent(ELightingRain rain)
        {
            Rain = rain;
        }
    }
}