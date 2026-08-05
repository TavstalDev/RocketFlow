using System;
using SDG.Unturned;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RCraftListener
    {
        public RCraftListener()
        {
            PlayerCrafting.OnCraftBlueprintRequestedV2 += OnCraftBlueprintRequested;
        }

        private void OnCraftBlueprintRequested(PlayerCrafting crafting, ref Blueprint blueprint, ref bool shouldAllow) =>
            throw new NotImplementedException();
    }
}
