using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Vehicle
{
    public class VehicleRepairEvent : Event, ICancellable
    {
        public CSteamID InstigatorSteamID { get; }
        public InteractableVehicle Vehicle { get; }
        public ushort PendingTotalHealing { get; set; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }
        
        public VehicleRepairEvent(CSteamID instigatorSteamID, InteractableVehicle vehicle, ref ushort pendingTotalHealing, ref bool shouldAllow)
        {
            InstigatorSteamID = instigatorSteamID;
            Vehicle = vehicle;
            PendingTotalHealing = pendingTotalHealing;
            ShouldAllow = shouldAllow;
        }
    }
}