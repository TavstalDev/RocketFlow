using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Barricade
{
    public class BarricadeDamageEvent : Event, ICancellable
    {
        public CSteamID Instigator { get; }
        
        public Transform BarricadeTransform { get; }
        
        public ushort PendingTotalDamage { get; set; }
        
        public bool ShouldAllow { get; set; }
        
        public EDamageOrigin Origin { get; }
        
        public bool IsCancelled { get; set; }

        public BarricadeDamageEvent(CSteamID instigator, Transform barricadeTransform, ref ushort pendingTotalDamage, ref bool shouldAllow, EDamageOrigin origin)
        {
            Instigator = instigator;
            BarricadeTransform = barricadeTransform;
            PendingTotalDamage = pendingTotalDamage;
            ShouldAllow = shouldAllow;
            Origin = origin;
        }
    }
}