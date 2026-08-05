using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerPreConnectEvent : Event
    {
        public UnturnedPlayer Player { get; private set; }
        
        public PlayerPreConnectEvent(UnturnedPlayer player)
        {
            Player = player;
        }
    }
}