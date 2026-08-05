using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Vehicle
{
    public class VehicleEnterEvent : Event, ICancellable
    {
        public SDG.Unturned.Player Player { get; }
        public InteractableVehicle Vehicle { get; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }
        
        public VehicleEnterEvent(SDG.Unturned.Player player, InteractableVehicle vehicle, ref bool shouldAllow)
        {
            Player = player;
            Vehicle = vehicle;
            ShouldAllow = shouldAllow;
        }
    }
}