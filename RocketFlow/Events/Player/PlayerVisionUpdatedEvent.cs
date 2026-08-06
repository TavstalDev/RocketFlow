using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerVisionUpdatedEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public bool IsViewing { get; }
        
        public PlayerVisionUpdatedEvent(UnturnedPlayer player, bool isViewing)
        {
            Player = player;
            IsViewing = isViewing;
        }
    }
}
