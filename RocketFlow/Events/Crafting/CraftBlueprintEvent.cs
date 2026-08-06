using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Crafting
{
    public class CraftBlueprintEvent : Event, ICancellable
    {
        public PlayerCrafting Crafting { get; }
        
        public Blueprint Blueprint { get; set; }
        
        public bool ShouldAllow { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public CraftBlueprintEvent(PlayerCrafting crafting, ref Blueprint blueprint, ref bool shouldAllow)
        {
            Crafting = crafting;
            Blueprint = blueprint;
            ShouldAllow = shouldAllow;
        }
    }
}
