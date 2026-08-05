using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerInventoryEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public InventoryGroup Group { get; }
        
        public byte Index { get; }
        
        public ItemJar ItemJar { get; }

        public PlayerInventoryEvent(UnturnedPlayer player, InventoryGroup group, byte index, ItemJar itemJar)
        {
            Player = player;
            Group = group;
            Index = index;
            ItemJar = itemJar;
        }
    }
}