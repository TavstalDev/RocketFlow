using Steamworks;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Structure
{
    public class StructureRepairEvent : Event, ICancellable
    {
        public CSteamID Instigator { get; }
        public Transform Transform { get; }
        public float PendingTotalHealing { get; set; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }
        
        public StructureRepairEvent(CSteamID instigatorSteamID, Transform structureTransform, ref float pendingTotalHealing, ref bool shouldAllow)
        {
            Instigator = instigatorSteamID;
            Transform = structureTransform;
            PendingTotalHealing = pendingTotalHealing;
            ShouldAllow = shouldAllow;
        }
    }
}