using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.World
{
    public class WorldHarvestEvent : Event, ICancellable
    {
        public InteractableFarm Harvestable { get; }
        
        public SteamPlayer InstigatorPlayer { get; }
        
        public bool ShouldAllow { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public WorldHarvestEvent(InteractableFarm harvestable, SteamPlayer instigatorPlayer, ref bool shouldAllow)
        {
            Harvestable = harvestable;
            InstigatorPlayer = instigatorPlayer;
            ShouldAllow = shouldAllow;
        }
    }
}
