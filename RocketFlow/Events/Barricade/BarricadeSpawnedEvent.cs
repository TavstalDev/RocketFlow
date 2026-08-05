using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Barricade
{
    public class BarricadeSpawnedEvent : Event
    {
        public BarricadeRegion Region { get; }
        
        public BarricadeDrop Drop { get; }
        
        public BarricadeSpawnedEvent(BarricadeRegion region, BarricadeDrop drop)
        {
            Region = region;
            Drop = drop;
        }
    }
}