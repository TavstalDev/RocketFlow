using System;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RWorldListener
    {
        public RWorldListener()
        {
            ObjectManager.onDamageObjectRequested += OnDamageObjectRequested;
            ResourceManager.onDamageResourceRequested += OnDamageResourceRequested;
            InteractableFarm.OnHarvestRequested_Global += OnHarvestRequested;
        }

        private void OnDamageObjectRequested(CSteamID instigatorSteamID, Transform objectTransform, byte section,
            ref ushort pendingTotalDamage, ref bool shouldAllow, EDamageOrigin damageOrigin) =>
            throw new NotImplementedException();

        private void OnDamageResourceRequested(CSteamID instigatorSteamID, Transform objectTransform,
            ref ushort pendingTotalDamage, ref bool shouldAllow, EDamageOrigin damageOrigin) =>
            throw new NotImplementedException();

        private void OnHarvestRequested(InteractableFarm harvestable, SteamPlayer instigatorPlayer, ref bool shouldAllow) =>
            throw new NotImplementedException();
    }
}
