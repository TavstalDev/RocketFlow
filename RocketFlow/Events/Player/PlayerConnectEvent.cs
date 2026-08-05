using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerConnectEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public PlayerConnectEvent(UnturnedPlayer player)
        {
            Player = player;
        }
    }
}