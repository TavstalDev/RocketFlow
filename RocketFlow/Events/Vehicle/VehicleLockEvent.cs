using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Vehicle
{
    public class VehicleLockEvent : Event, ICancellable
    {
        public InteractableVehicle Vehicle { get; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }
        
        public VehicleLockEvent(InteractableVehicle vehicle, ref bool shouldAllow)
        {
            Vehicle = vehicle;
            ShouldAllow = shouldAllow;
        }
    }
}