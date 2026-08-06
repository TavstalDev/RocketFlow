using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Player.Life
{
    public class PlayerReviveEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public Vector3 Position { get; }
        
        public byte Angle { get; }

        public PlayerReviveEvent(UnturnedPlayer player, Vector3 position, byte angle)
        {
            Player = player;
            Position = position;
            Angle = angle;
        }
    }
}