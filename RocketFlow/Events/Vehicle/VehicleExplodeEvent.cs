using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Vehicle
{
    public class VehicleExplodeEvent : Event
    {
        public InteractableVehicle Vehicle { get; }
        
        public VehicleExplodeEvent(InteractableVehicle vehicle)
        {
            Vehicle = vehicle;
        }
    }
}