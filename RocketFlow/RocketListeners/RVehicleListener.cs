using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Vehicle;
using UnityEngine;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RVehicleListener
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

        private void OnDamageTireRequested(CSteamID instigatorSteamID, InteractableVehicle vehicle, int tireIndex, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            var e = EventManager.Fire(new VehicleTireDamageEvent(instigatorSteamID, vehicle, tireIndex, ref shouldAllow, damageOrigin));
            shouldAllow = e.ShouldAllow;
        }

        private void OnDamageVehicleRequested(CSteamID instigatorSteamID, InteractableVehicle vehicle, ref ushort pendingTotalDamage, ref bool canRepair,
            ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            var e = EventManager.Fire(new VehicleDamageEvent(instigatorSteamID, vehicle, ref pendingTotalDamage, ref canRepair, ref shouldAllow, damageOrigin));
            pendingTotalDamage = e.PendingTotalDamage;
            canRepair = e.CanRepair;
            shouldAllow = e.ShouldAllow;
        }

        private void OnRepairVehicleRequested(CSteamID instigatorSteamID, InteractableVehicle vehicle, ref ushort pendingTotalHealing, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new VehicleRepairEvent(instigatorSteamID, vehicle, ref pendingTotalHealing, ref shouldAllow));
            pendingTotalHealing = e.PendingTotalHealing;
            shouldAllow = e.ShouldAllow;
        }

        private void OnSiphonVehicleRequested(InteractableVehicle vehicle, Player instigatingPlayer, ref bool shouldAllow, ref ushort desiredAmount)
        {
            var e = EventManager.Fire(new VehicleSiphonEvent(vehicle, instigatingPlayer, ref shouldAllow, ref desiredAmount));
            shouldAllow = e.ShouldAllow;
            desiredAmount = e.DesiredAmount;
        }

        private void OnVehicleCarjacked(InteractableVehicle vehicle, Player instigatingPlayer, ref bool allow, ref Vector3 force, ref Vector3 torque)
        {
            var e = EventManager.Fire(new VehicleCarjackEvent(vehicle, instigatingPlayer, ref allow, ref force, ref torque));
            allow = e.Allow;
            force = e.Force;
            torque = e.Torque;
        }

        private void OnVehicleLockpicked(InteractableVehicle vehicle, Player instigatingPlayer, ref bool allow)
        {
            var e = EventManager.Fire(new VehicleLockpickEvent(vehicle, instigatingPlayer, ref allow));
            allow = e.Allow;
        }

        private void OnVehicleExploded(InteractableVehicle vehicle) =>
            EventManager.Fire(new VehicleExplodeEvent(vehicle));

        private void OnEnterVehicleRequested(Player player, InteractableVehicle vehicle, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new VehicleEnterEvent(player, vehicle, ref shouldAllow));
            shouldAllow = e.ShouldAllow;
        }

        private void OnExitVehicleRequested(Player player, InteractableVehicle vehicle, ref bool shouldAllow, ref Vector3 pendingLocation, ref float pendingYaw)
        {
            var e = EventManager.Fire(new VehicleExitEvent(player, vehicle, ref shouldAllow, ref pendingLocation, ref pendingYaw));
            shouldAllow = e.ShouldAllow;
            pendingLocation = e.PendingLocation;
            pendingYaw = e.PendingYaw;
        }

        private void OnSwapSeatRequested(Player player, InteractableVehicle vehicle, ref bool shouldAllow, byte fromSeatIndex, ref byte toSeatIndex)
        {
            var e = EventManager.Fire(new VehicleSwapSeatEvent(player, vehicle, ref shouldAllow, fromSeatIndex, ref toSeatIndex));
            shouldAllow = e.ShouldAllow;
            toSeatIndex = e.ToSeatIndex;
        }

        private void OnPreDestroyVehicle(InteractableVehicle vehicle) =>
            EventManager.Fire(new VehiclePreDestroyEvent(vehicle));

        private void OnToggledVehicleLock(InteractableVehicle vehicle) =>
            EventManager.Fire(new VehicleLockedEvent(vehicle));

        private void OnToggleVehicleLockRequested(InteractableVehicle vehicle, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new VehicleLockEvent(vehicle, ref shouldAllow));
            shouldAllow = e.ShouldAllow;
        }
    }
}