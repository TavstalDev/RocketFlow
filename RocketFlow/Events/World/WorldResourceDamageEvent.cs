using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.World
{
    public class WorldResourceDamageEvent : Event, ICancellable
    {
        public CSteamID InstigatorSteamID { get; }
        
        public Transform ObjectTransform { get; }
        
        public ushort PendingTotalDamage { get; set; }
        
        public bool ShouldAllow { get; set; }
        
        public EDamageOrigin DamageOrigin { get; }
        
        public bool IsCancelled { get; set; }
        
        public WorldResourceDamageEvent(CSteamID instigatorSteamID, Transform objectTransform,
            ref ushort pendingTotalDamage, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            InstigatorSteamID = instigatorSteamID;
            ObjectTransform = objectTransform;
            PendingTotalDamage = pendingTotalDamage;
            ShouldAllow = shouldAllow;
            DamageOrigin = damageOrigin;
        }
    }
}
