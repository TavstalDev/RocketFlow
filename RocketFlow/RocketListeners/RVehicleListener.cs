using SDG.Unturned;
using Steamworks;
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

        private void OnDamageTireRequested(CSteamID instigatorSteamID, InteractableVehicle vehicle, int tireIndex, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            throw new System.NotImplementedException();
        }

        private void OnDamageVehicleRequested(CSteamID instigatorSteamID, InteractableVehicle vehicle, ref ushort pendingTotalDamage, ref bool canRepair, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            throw new System.NotImplementedException();
        }

        private void OnRepairVehicleRequested(CSteamID instigatorSteamID, InteractableVehicle vehicle, ref ushort pendingTotalHealing, ref bool shouldAllow)
        {
            throw new System.NotImplementedException();
        }

        private void OnSiphonVehicleRequested(InteractableVehicle vehicle, SDG.Unturned.Player instigatingPlayer, ref bool shouldAllow, ref ushort desiredAmount)
        {
            throw new System.NotImplementedException();
        }

        private void OnVehicleCarjacked(InteractableVehicle vehicle, SDG.Unturned.Player instigatingPlayer, ref bool allow, ref Vector3 force, ref Vector3 torque)
        {
            throw new System.NotImplementedException();
        }

        private void OnVehicleLockpicked(InteractableVehicle vehicle, SDG.Unturned.Player instigatingPlayer, ref bool allow)
        {
            throw new System.NotImplementedException();
        }

        private void OnVehicleExploded(InteractableVehicle obj)
        {
            throw new System.NotImplementedException();
        }

        private void OnEnterVehicleRequested(SDG.Unturned.Player player, InteractableVehicle vehicle, ref bool shouldAllow)
        {
            throw new System.NotImplementedException();
        }

        private void OnExitVehicleRequested(SDG.Unturned.Player player, InteractableVehicle vehicle, ref bool shouldAllow, ref Vector3 pendingLocation, ref float pendingYaw)
        {
            throw new System.NotImplementedException();
        }

        private void OnSwapSeatRequested(SDG.Unturned.Player player, InteractableVehicle vehicle, ref bool shouldAllow, byte fromSeatIndex, ref byte toSeatIndex)
        {
            throw new System.NotImplementedException();
        }

        private void OnPreDestroyVehicle(InteractableVehicle obj)
        {
            throw new System.NotImplementedException();
        }

        private void OnToggledVehicleLock(InteractableVehicle obj)
        {
            throw new System.NotImplementedException();
        }

        private void OnToggleVehicleLockRequested(InteractableVehicle vehicle, ref bool shouldAllow)
        {
            throw new System.NotImplementedException();
        }
    }
}