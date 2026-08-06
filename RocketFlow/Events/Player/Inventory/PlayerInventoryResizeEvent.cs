using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Inventory
{
    public class PlayerInventoryResizeEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public InventoryGroup Group { get; }
        
        public byte X {  get; }
        
        public byte Y { get; }

        public PlayerInventoryResizeEvent(UnturnedPlayer player, InventoryGroup group, byte x, byte y)
        {
            Player = player;
            Group = group;
            X = x;
            Y = y;
        }
    }
}