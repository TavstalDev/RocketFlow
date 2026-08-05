using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Vehicle
{
    public class VehicleDamageEvent : Event, ICancellable
    {
        public CSteamID InstigatorSteamID { get; }
        
        public InteractableVehicle Vehicle { get; }
        
        public ushort PendingTotalDamage { get; set; }
        
        public bool CanRepair { get; set; }
        
        public bool ShouldAllow { get; set; }
        
        public EDamageOrigin DamageOrigin { get; }
        
        public bool IsCancelled { get; set; }
        
        public VehicleDamageEvent(CSteamID instigatorSteamID, InteractableVehicle vehicle,
            ref ushort pendingTotalDamage, ref bool canRepair, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            InstigatorSteamID = instigatorSteamID;
            Vehicle = vehicle;
            PendingTotalDamage = pendingTotalDamage;
            CanRepair = canRepair;
            ShouldAllow = shouldAllow;
            DamageOrigin = damageOrigin;
        }
    }
}