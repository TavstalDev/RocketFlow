using Steamworks;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Barricade
{
    public class BarricadeRepairEvent : Event, ICancellable
    {
        public CSteamID InstigatorSteamID { get; }
        
        public Transform BarricadeTransform { get; }
        
        public float PendingTotalHealing { get; set; }
        
        public bool ShouldAllow { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public BarricadeRepairEvent(CSteamID instigatorSteamID, Transform barricadeTransform, ref float pendingTotalHealing, ref bool shouldAllow)
        {
            InstigatorSteamID = instigatorSteamID;
            BarricadeTransform = barricadeTransform;
            PendingTotalHealing = pendingTotalHealing;
            ShouldAllow = shouldAllow;
        }
    }
}