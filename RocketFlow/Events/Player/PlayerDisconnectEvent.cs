using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerDisconnectEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public PlayerDisconnectEvent(UnturnedPlayer player)
        {
            Player = player;
        }
    }
}