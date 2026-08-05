using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Vehicle
{
    public class VehicleLockpickEvent : Event, ICancellable
    {
        public InteractableVehicle Vehicle { get; }
        public SDG.Unturned.Player InstigatingPlayer { get; }
        public bool Allow { get; set; }
        public bool IsCancelled { get; set; }
        
        public VehicleLockpickEvent(InteractableVehicle vehicle, SDG.Unturned.Player instigatingPlayer, ref bool allow)
        {
            Vehicle = vehicle;
            InstigatingPlayer = instigatingPlayer;
            Allow = allow;
        }
    }
}