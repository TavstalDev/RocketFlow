using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Crafting;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RCraftListener
    {
        public RCraftListener()
        {
            PlayerCrafting.OnCraftBlueprintRequestedV2 += OnCraftBlueprintRequested;
        }

        private void OnCraftBlueprintRequested(PlayerCrafting crafting, ref Blueprint blueprint, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new CraftBlueprintEvent(crafting, ref blueprint, ref shouldAllow));
            blueprint = e.Blueprint;
            shouldAllow = e.ShouldAllow;
        }
    }
}
