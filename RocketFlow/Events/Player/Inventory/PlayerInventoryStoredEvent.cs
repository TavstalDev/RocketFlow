using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Inventory
{
    public class PlayerInventoryStoredEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public PlayerInventoryStoredEvent(UnturnedPlayer player)
        {
            Player = player;
        }
    }
}