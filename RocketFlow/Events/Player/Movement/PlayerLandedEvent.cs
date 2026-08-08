using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Movement
{
    public class PlayerLandedEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public float Velocity { get;  }
        
        public PlayerLandedEvent(UnturnedPlayer player, float velocity)
        {
            Player = player;
            Velocity = velocity;
        }
    }
}