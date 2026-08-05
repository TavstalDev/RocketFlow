using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Structure
{
    public class StructureSpawnedEvent : Event
    {
        public StructureRegion Region { get; }
        
        public StructureDrop Drop { get; }
        
        public StructureSpawnedEvent(StructureRegion region, StructureDrop drop)
        {
            Region = region;
            Drop = drop;
        }
    }
}