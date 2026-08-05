using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Vehicle
{
    public class VehicleLockedEvent : Event
    {
        public InteractableVehicle Vehicle { get; }
        
        public VehicleLockedEvent(InteractableVehicle vehicle)
        {
            Vehicle = vehicle;
        }
    }
}