using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Vehicle
{
    public class VehicleTireDamageEvent : Event, ICancellable
    {
        public CSteamID InstigatorSteamID { get; }
        public InteractableVehicle Vehicle { get; }
        public int TireIndex { get; }
        public bool ShouldAllow { get; set; }
        public EDamageOrigin DamageOrigin { get; }
        public bool IsCancelled { get; set; }

        public VehicleTireDamageEvent(CSteamID instigatorSteamID, InteractableVehicle vehicle, int tireIndex,
            ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            InstigatorSteamID = instigatorSteamID;
            Vehicle = vehicle;
            TireIndex = tireIndex;
            ShouldAllow = shouldAllow;
            DamageOrigin = damageOrigin;
        }
    }
}