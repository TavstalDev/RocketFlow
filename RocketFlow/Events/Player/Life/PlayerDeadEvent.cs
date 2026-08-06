using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Player.Life
{
    public class PlayerDeadEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public Vector3 Position { get; }
        
        public PlayerDeadEvent(UnturnedPlayer player, Vector3 position)
        {
            Player = player;
            Position = position;
        }
    }
}