using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Lighting
{
    public class LightSnowEvent : Event
    {
        public ELightingSnow Snow { get; }

        public LightSnowEvent(ELightingSnow snow)
        {
            Snow = snow;
        }
    }
}