using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Vehicle
{
    public class VehicleCarjackEvent : Event, ICancellable
    {
        public InteractableVehicle Vehicle { get; }
        public SDG.Unturned.Player InstigatingPlayer { get; }
        public bool Allow { get; set; }
        public Vector3 Force { get; set; }
        public Vector3 Torque { get; set; }
        public bool IsCancelled { get; set; }
        
        
        public VehicleCarjackEvent(InteractableVehicle vehicle, SDG.Unturned.Player instigatingPlayer, ref bool allow, ref Vector3 force, ref Vector3 torque)
        {
            Vehicle = vehicle;
            InstigatingPlayer = instigatingPlayer;
            Allow = allow;
            Force = force;
            Torque = torque;
        }
    }
}