using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Vehicle;
using UnityEngine;

namespace Tavstal.RocketFlow.RocketListeners
{
    public class RVehicleListener
    {
        public RVehicleListener()
        {
            VehicleManager.onDamageTireRequested += OnDamageTireRequested;
            VehicleManager.onDamageVehicleRequested += OnDamageVehicleRequested;
            VehicleManager.onRepairVehicleRequested += OnRepairVehicleRequested;
            VehicleManager.onSiphonVehicleRequested += OnSiphonVehicleRequested;
            VehicleManager.onVehicleCarjacked += OnVehicleCarjacked;
            VehicleManager.onVehicleLockpicked += OnVehicleLockpicked;
            VehicleManager.OnVehicleExploded += OnVehicleExploded;
            VehicleManager.onEnterVehicleRequested += OnEnterVehicleRequested;
            VehicleManager.onExitVehicleRequested += OnExitVehicleRequested;
            VehicleManager.onSwapSeatRequested += OnSwapSeatRequested;
            VehicleManager.OnPreDestroyVehicle += OnPreDestroyVehicle;
            VehicleManager.OnToggledVehicleLock += OnToggledVehicleLock;
            VehicleManager.OnToggleVehicleLockRequested += OnToggleVehicleLockRequested;
        }

        private void OnDamageTireRequested(CSteamID instigatorSteamID, InteractableVehicle vehicle, int tireIndex, ref bool shouldAllow, EDamageOrigin damageOrigin) =>
            EventManager.Fire(new VehicleTireDamageEvent(instigatorSteamID, vehicle, tireIndex, ref shouldAllow, damageOrigin));

        private void OnDamageVehicleRequested(CSteamID instigatorSteamID, InteractableVehicle vehicle, ref ushort pendingTotalDamage, ref bool canRepair,
            ref bool shouldAllow, EDamageOrigin damageOrigin) =>
            EventManager.Fire(new VehicleDamageEvent(instigatorSteamID, vehicle, ref pendingTotalDamage, ref canRepair, ref shouldAllow, damageOrigin));

        private void OnRepairVehicleRequested(CSteamID instigatorSteamID, InteractableVehicle vehicle, ref ushort pendingTotalHealing, ref bool shouldAllow) =>
            EventManager.Fire(new VehicleRepairEvent(instigatorSteamID, vehicle, ref pendingTotalHealing, ref shouldAllow));

        private void OnSiphonVehicleRequested(InteractableVehicle vehicle, Player instigatingPlayer, ref bool shouldAllow, ref ushort desiredAmount) =>
            EventManager.Fire(new VehicleSiphonEvent(vehicle, instigatingPlayer, ref shouldAllow, ref desiredAmount));

        private void OnVehicleCarjacked(InteractableVehicle vehicle, Player instigatingPlayer, ref bool allow, ref Vector3 force, ref Vector3 torque) =>
            EventManager.Fire(new VehicleCarjackEvent(vehicle, instigatingPlayer, ref allow, ref force, ref torque));

        private void OnVehicleLockpicked(InteractableVehicle vehicle, Player instigatingPlayer, ref bool allow) =>
            EventManager.Fire(new VehicleLockpickEvent(vehicle, instigatingPlayer, ref allow));

        private void OnVehicleExploded(InteractableVehicle vehicle) =>
            EventManager.Fire(new VehicleExplodeEvent(vehicle));

        private void OnEnterVehicleRequested(Player player, InteractableVehicle vehicle, ref bool shouldAllow) =>
            EventManager.Fire(new VehicleEnterEvent(player, vehicle, ref shouldAllow));

        private void OnExitVehicleRequested(Player player, InteractableVehicle vehicle, ref bool shouldAllow, ref Vector3 pendingLocation, ref float pendingYaw) =>
            EventManager.Fire(new VehicleExitEvent(player, vehicle, ref shouldAllow, ref pendingLocation, ref pendingYaw));

        private void OnSwapSeatRequested(Player player, InteractableVehicle vehicle, ref bool shouldAllow, byte fromSeatIndex, ref byte toSeatIndex) =>
            EventManager.Fire(new VehicleSwapSeatEvent(player, vehicle, ref shouldAllow, fromSeatIndex, ref toSeatIndex));

        private void OnPreDestroyVehicle(InteractableVehicle vehicle) =>
            EventManager.Fire(new VehiclePreDestroyEvent(vehicle));

        private void OnToggledVehicleLock(InteractableVehicle vehicle) =>
            EventManager.Fire(new VehicleLockedEvent(vehicle));

        private void OnToggleVehicleLockRequested(InteractableVehicle vehicle, ref bool shouldAllow) =>
            EventManager.Fire(new VehicleLockEvent(vehicle, ref shouldAllow));
    }
}