using Rocket.Unturned.Player;
using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Inventory
{
    public class PlayerInventoryDropEvent : Event, ICancellable
    {
        public UnturnedPlayer Player { get; }
        public PlayerInventory Inventory { get; }
        public SDG.Unturned.Item Item { get; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }

        public PlayerInventoryDropEvent(UnturnedPlayer player, PlayerInventory inventory, SDG.Unturned.Item item, ref bool shouldAllow)
        {
            Player = player;
            Inventory = inventory;
            Item = item;
            ShouldAllow = shouldAllow;
        }
    }
}