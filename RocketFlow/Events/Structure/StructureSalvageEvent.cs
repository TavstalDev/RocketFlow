using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Structure
{
    public class StructureSalvageEvent : Event, ICancellable
    {
        public StructureDrop Structure { get; }
        public SteamPlayer InstigatorClient { get; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }
        
        public StructureSalvageEvent(StructureDrop structure, SteamPlayer instigatorClient, ref bool shouldAllow)
        {
            Structure = structure;
            InstigatorClient = instigatorClient;
            ShouldAllow = shouldAllow;
        }
    }
}