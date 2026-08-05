using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Structure;
using UnityEngine;

namespace Tavstal.RocketFlow.RocketListeners
{
    public class RStructureListener
    {
        public RStructureListener()
        {
            StructureManager.onStructureSpawned += OnStructureSpawned;
            StructureManager.onDamageStructureRequested += OnDamageStructureRequested;
            StructureManager.onDeployStructureRequested += OnDeployStructureRequested;
            StructureManager.onTransformRequested += OnTransformRequested;
            StructureManager.OnRepaired += OnRepaired;
            StructureManager.OnRepairRequested += OnRepairRequested;
            StructureDrop.OnSalvageRequested_Global += OnSalvageRequested;
        }

        private void OnStructureSpawned(StructureRegion region, StructureDrop drop) =>
            EventManager.Fire(new StructureSpawnedEvent(region, drop));

        private void OnDamageStructureRequested(CSteamID instigatorSteamID, Transform structureTransform, ref ushort pendingTotalDamage, ref bool shouldAllow, EDamageOrigin damageOrigin) =>
            EventManager.Fire(new StructureDamageEvent(instigatorSteamID, structureTransform, ref pendingTotalDamage, ref shouldAllow, damageOrigin));

        private void OnDeployStructureRequested(Structure structure, ItemStructureAsset asset, ref Vector3 point, ref float angleX, ref float angleY, ref float angleZ, ref ulong owner, 
            ref ulong group, ref bool shouldAllow) =>
            EventManager.Fire(new StructureDeployEvent(structure, asset, ref point, ref angleX, ref angleY, ref angleZ, ref owner, ref group, ref shouldAllow));

        private void OnTransformRequested(CSteamID instigator, byte x, byte y, uint instanceID, ref Vector3 point, ref byte angleX, ref byte angleY, ref byte angleZ, ref bool shouldAllow) =>
            EventManager.Fire(new StructureTransformEvent(instigator, x, y, instanceID, ref point, ref angleX, ref angleY, ref angleZ, ref shouldAllow));

        private void OnRepaired(CSteamID instigatorSteamID, Transform structureTransform, float totalHealing) =>
            EventManager.Fire(new StructureRepairedEvent(instigatorSteamID, structureTransform, totalHealing));

        private void OnRepairRequested(CSteamID instigatorSteamID, Transform structureTransform, ref float pendingTotalHealing, ref bool shouldAllow) =>
            EventManager.Fire(new StructureRepairEvent(instigatorSteamID, structureTransform, ref pendingTotalHealing, ref shouldAllow));
        
        private void OnSalvageRequested(StructureDrop structure, SteamPlayer instigatorClient, ref bool shouldAllow) =>
            EventManager.Fire(new StructureSalvageEvent(structure, instigatorClient, ref shouldAllow));
    }
}