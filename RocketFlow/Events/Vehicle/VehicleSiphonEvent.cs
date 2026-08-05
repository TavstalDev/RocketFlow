using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Vehicle
{
    public class VehicleSiphonEvent : Event, ICancellable
    {
        public InteractableVehicle Vehicle { get; }
        public SDG.Unturned.Player InstigatingPlayer { get; }
        public bool ShouldAllow { get; set; }
        public ushort DesiredAmount { get; set; }
        public bool IsCancelled { get; set; }
        
        public VehicleSiphonEvent(InteractableVehicle vehicle, SDG.Unturned.Player instigatingPlayer, ref bool shouldAllow, ref ushort desiredAmount)
        {
            Vehicle = vehicle;
            InstigatingPlayer = instigatingPlayer;
            ShouldAllow = shouldAllow;
            DesiredAmount = desiredAmount;
        }
    }
}