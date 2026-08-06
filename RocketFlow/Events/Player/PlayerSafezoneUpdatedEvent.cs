using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerSafezoneUpdatedEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public bool IsSafe { get; }
        
        public PlayerSafezoneUpdatedEvent(UnturnedPlayer player, bool isSafe)
        {
            Player = player;
            IsSafe = isSafe;
        }
    }
}
