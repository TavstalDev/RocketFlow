using System.Collections.Generic;
using Rocket.Unturned;
using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Provider;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RProviderListener : Event
    {
        public RProviderListener()
        {
            U.Events.OnShutdown += OnShutdown;
            Provider.onBanPlayerRequestedV2 += OnBanPlayerRequested;
            Provider.onUnbanPlayerRequested += OnUnbanPlayerRequested;
        }

        private void OnShutdown() =>
            EventManager.Fire(new ProviderShutdownEvent());
        
        private void OnBanPlayerRequested(CSteamID instigator, CSteamID playerToBan, uint ipToBan,
            IEnumerable<byte[]> hwidsToBan, ref string reason, ref uint duration, ref bool shouldVanillaBan)
        {
            var e = EventManager.Fire(new ProviderBanEvent(instigator, playerToBan, ipToBan, hwidsToBan, ref reason, ref duration, ref shouldVanillaBan));
            reason = e.Reason;
            duration = e.Duration;
            shouldVanillaBan = e.ShouldVanillaBan;
        }

        private void OnUnbanPlayerRequested(CSteamID instigator, CSteamID playerToUnban, ref bool shouldVanillaUnban)
        {
            var e = EventManager.Fire(new ProviderUnbanEvent(instigator, playerToUnban, ref shouldVanillaUnban));
            shouldVanillaUnban = e.ShouldVanillaUnban;
        }
    }
}