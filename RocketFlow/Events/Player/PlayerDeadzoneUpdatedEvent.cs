using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerDeadzoneUpdatedEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public bool IsInDeadzone { get; }
        
        public PlayerDeadzoneUpdatedEvent(UnturnedPlayer player, bool isInDeadzone)
        {
            Player = player;
            IsInDeadzone = isInDeadzone;
        }
    }
}
