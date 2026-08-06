using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Player.Movement
{
    public class PlayerMoveEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public Vector3 Position { get; }
        
        public PlayerMoveEvent(UnturnedPlayer player, Vector3 position)
        {
            Player = player;
            Position = position;
        }
    }
}