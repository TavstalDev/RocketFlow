using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.World
{
    public class WorldObjectDamageEvent : Event, ICancellable
    {
        public CSteamID InstigatorSteamID { get; }
        
        public Transform ObjectTransform { get; }
        
        public byte Section { get; }
        
        public ushort PendingTotalDamage { get; set; }
        
        public bool ShouldAllow { get; set; }
        
        public EDamageOrigin DamageOrigin { get; }
        
        public bool IsCancelled { get; set; }
        
        public WorldObjectDamageEvent(CSteamID instigatorSteamID, Transform objectTransform, byte section,
            ref ushort pendingTotalDamage, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            InstigatorSteamID = instigatorSteamID;
            ObjectTransform = objectTransform;
            Section = section;
            PendingTotalDamage = pendingTotalDamage;
            ShouldAllow = shouldAllow;
            DamageOrigin = damageOrigin;
        }
    }
}
