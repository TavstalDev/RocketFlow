using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Barricade;
using UnityEngine;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RBarricadeListener
    {
        public RBarricadeListener()
        {
            BarricadeManager.onBarricadeSpawned += OnBarricadeSpawned;
            BarricadeManager.onDamageBarricadeRequested += OnDamageBarricadeRequested;
            BarricadeManager.onDeployBarricadeRequested += OnDeployBarricadeRequested;
            BarricadeManager.onModifySignRequested += OnModifySignRequested;
            BarricadeManager.onOpenStorageRequested += OnOpenStorageRequested;
            BarricadeManager.onTransformRequested += OnTransformRequested;
            BarricadeManager.OnRepaired += OnRepaired;
            BarricadeManager.OnRepairRequested += OnRepairRequested;
            BarricadeDrop.OnSalvageRequested_Global += OnSalvageRequested;
        }

        private void OnDamageBarricadeRequested(CSteamID instigatorSteamID, Transform barricadeTransform, ref ushort pendingTotalDamage, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            var e = EventManager.Fire(new BarricadeDamageEvent(instigatorSteamID, barricadeTransform, ref pendingTotalDamage, ref shouldAllow, damageOrigin));
            pendingTotalDamage = e.PendingTotalDamage;
            shouldAllow = e.ShouldAllow;
        }

        private void OnDeployBarricadeRequested(Barricade barricade, ItemBarricadeAsset asset, Transform hit, ref Vector3 point, ref float angleX, ref float angleY, ref float angleZ,
            ref ulong owner, ref ulong group, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new BarricadeDeployEvent(barricade, asset, hit, ref point, ref angleX, ref angleY, ref angleZ, ref owner, ref group, ref shouldAllow));
            point = e.Point;
            angleX = e.AngleX;
            angleY = e.AngleY;
            angleZ = e.AngleZ;
            owner = e.Owner;
            group = e.Group;
            shouldAllow = e.ShouldAllow;
        }

        private void OnModifySignRequested(CSteamID instigator, InteractableSign sign, ref string text, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new BarricadeSignModifyEvent(instigator, sign, ref text, ref shouldAllow));
            text = e.Text;
            shouldAllow = e.ShouldAllow;
        }

        private void OnTransformRequested(CSteamID instigator, byte x, byte y, ushort plant, uint instanceID, ref Vector3 point, ref byte angleX, ref byte angleY, ref byte angleZ, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new BarricadeTransformEvent(instigator, x, y, plant, instanceID, ref point, ref angleX, ref angleY, ref angleZ, ref shouldAllow));
            point = e.Point;
            angleX = e.AngleX;
            angleY = e.AngleY;
            angleZ = e.AngleZ;
            shouldAllow = e.ShouldAllow;
        }

        private void OnRepairRequested(CSteamID instigatorSteamID, Transform barricadeTransform, ref float pendingTotalHealing, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new BarricadeRepairEvent(instigatorSteamID, barricadeTransform, ref pendingTotalHealing, ref shouldAllow));
            pendingTotalHealing = e.PendingTotalHealing;
            shouldAllow = e.ShouldAllow;
        }

        private void OnRepaired(CSteamID instigatorSteamID, Transform barricadeTransform, float totalHealing) =>
            EventManager.Fire(new BarricadeRepairedEvent(instigatorSteamID, barricadeTransform, totalHealing));

        private void OnOpenStorageRequested(CSteamID instigator, InteractableStorage storage, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new BarricadeStorageOpenEvent(instigator, storage, ref shouldAllow));
            shouldAllow = e.ShouldAllow;
        }

        private void OnBarricadeSpawned(BarricadeRegion region, BarricadeDrop drop) =>
            EventManager.Fire(new BarricadeSpawnedEvent(region, drop));
        
        private void OnSalvageRequested(BarricadeDrop barricade, SteamPlayer instigatorClient, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new BarricadeSalvageEvent(barricade, instigatorClient, ref shouldAllow));
            shouldAllow = e.ShouldAllow;
        }
    }
}