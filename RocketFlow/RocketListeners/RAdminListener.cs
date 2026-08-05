using System;
using System.Collections.Generic;
using SDG.Unturned;
using Steamworks;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RAdminListener
    {
        public RAdminListener()
        {
            Provider.onBanPlayerRequestedV2 += OnBanPlayerRequested;
            Provider.onUnbanPlayerRequested += OnUnbanPlayerRequested;
        }

        private void OnBanPlayerRequested(CSteamID instigator, CSteamID playerToBan, uint ipToBan,
            IEnumerable<byte[]> hwidsToBan, ref string reason, ref uint duration, ref bool shouldVanillaBan) =>
            throw new NotImplementedException();

        private void OnUnbanPlayerRequested(CSteamID instigator, CSteamID playerToUnban, ref bool shouldVanillaUnban) =>
            throw new NotImplementedException();
    }
}
