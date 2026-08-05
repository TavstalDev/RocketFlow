using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Vehicle
{
    public class VehicleSwapSeatEvent : Event, ICancellable
    {
        public SDG.Unturned.Player Player { get; }
        public InteractableVehicle Vehicle { get; }
        public bool ShouldAllow { get; set; }
        public byte FromSeatIndex { get; }
        public byte ToSeatIndex { get; set; }
        public bool IsCancelled { get; set; }
        
        public VehicleSwapSeatEvent(SDG.Unturned.Player player, InteractableVehicle vehicle, ref bool shouldAllow, byte fromSeatIndex, ref byte toSeatIndex)
        {
            Player = player;
            Vehicle = vehicle;
            ShouldAllow = shouldAllow;
            FromSeatIndex = fromSeatIndex;
            ToSeatIndex = toSeatIndex;
        }
    }
}