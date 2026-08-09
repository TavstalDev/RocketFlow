using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.World;
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
            ref ushort pendingTotalDamage, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            var e = EventManager.Fire(new WorldObjectDamageEvent(instigatorSteamID, objectTransform, section, ref pendingTotalDamage, ref shouldAllow, damageOrigin));
            pendingTotalDamage = e.PendingTotalDamage;
            shouldAllow = e.ShouldAllow;
        }

        private void OnDamageResourceRequested(CSteamID instigatorSteamID, Transform objectTransform,
            ref ushort pendingTotalDamage, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            var e = EventManager.Fire(new WorldResourceDamageEvent(instigatorSteamID, objectTransform, ref pendingTotalDamage, ref shouldAllow, damageOrigin));
            pendingTotalDamage = e.PendingTotalDamage;
            shouldAllow = e.ShouldAllow;
        }

        private void OnHarvestRequested(InteractableFarm harvestable, SteamPlayer instigatorPlayer, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new WorldHarvestEvent(harvestable, instigatorPlayer, ref shouldAllow));
            shouldAllow = e.ShouldAllow;
        }
    }
}
