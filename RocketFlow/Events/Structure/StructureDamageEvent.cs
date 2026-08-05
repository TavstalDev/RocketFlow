using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Structure
{
    public class StructureDamageEvent : Event, ICancellable
    {
        public CSteamID Instigator { get; }
        public Transform Transform { get; }
        public ushort PendingTotalDamage { get; set; }
        public bool ShouldAllow { get; set; }
        public EDamageOrigin DamageOrigin { get; }
        public bool IsCancelled { get; set; }
        
        public StructureDamageEvent(CSteamID instigatorSteamID, Transform structureTransform,
            ref ushort pendingTotalDamage, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            Instigator = instigatorSteamID;
            Transform = structureTransform;
            PendingTotalDamage = pendingTotalDamage;
            ShouldAllow = shouldAllow;
            DamageOrigin = damageOrigin;
        }
    }
}