using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Vehicle
{
    public class VehiclePreDestroyEvent : Event
    {
        public InteractableVehicle Vehicle { get; }
        
        public VehiclePreDestroyEvent(InteractableVehicle vehicle)
        {
            Vehicle = vehicle;
        }
    }
}