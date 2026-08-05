using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Vehicle
{
    public class VehicleExitEvent : Event, ICancellable
    {
        public SDG.Unturned.Player Player { get; }
        public InteractableVehicle Vehicle { get; }
        public bool ShouldAllow { get; set; }
        public Vector3 PendingLocation { get; set; }
        public float PendingYaw { get; set; }
        public bool IsCancelled { get; set; }
        
        public VehicleExitEvent(SDG.Unturned.Player player, InteractableVehicle vehicle, ref bool shouldAllow, ref Vector3 pendingLocation, ref float pendingYaw)
        {
            Player = player;
            Vehicle = vehicle;
            ShouldAllow = shouldAllow;
            PendingLocation = pendingLocation;
            PendingYaw = pendingYaw;
        }
    }
}