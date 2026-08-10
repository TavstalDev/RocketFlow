using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Player.Life
{
    public class PlayerHurtEvent : Event
    {
        public SDG.Unturned.Player Player { get; }
        public byte Damage { get; }
        public Vector3 Force { get; }
        public EDeathCause Cause { get; }
        public ELimb Limb { get; }
        public CSteamID Killer { get; }

        public PlayerHurtEvent(SDG.Unturned.Player player, byte damage, Vector3 force, EDeathCause cause, ELimb limb, CSteamID killer)
        {
            Player = player;
            Damage = damage;
            Force = force;
            Cause = cause;
            Limb = limb;
            Killer = killer;
        }
    }
}