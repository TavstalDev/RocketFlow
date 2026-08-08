using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Inventory
{
    public class PlayerInventoryStateUpdatedEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public PlayerInventoryStateUpdatedEvent(UnturnedPlayer player)
        {
            Player = player;
        }
    }
}