using Rocket.Unturned.Player;
using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerDamagedEvent : Event, ICancellable
    {
        public UnturnedPlayer Player { get; }
        
        public EDeathCause Cause { get; set; }
        
        public ELimb Limb { get; set; }
        
        public UnturnedPlayer Killer { get; set; }
        
        public Vector3 Direction { get; set; }
        
        public float Damage { get; set; }
        
        public float Times { get; set; }
        
        public bool CanDamage { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public PlayerDamagedEvent(UnturnedPlayer player, ref EDeathCause cause, ref ELimb limb,
            ref UnturnedPlayer killer, ref Vector3 direction, ref float damage, ref float times,
            ref bool canDamage)
        {
            Player = player;
            Cause = cause;
            Limb = limb;
            Killer = killer;
            Direction = direction;
            Damage = damage;
            Times = times;
            CanDamage = canDamage;
        }
    }
}
