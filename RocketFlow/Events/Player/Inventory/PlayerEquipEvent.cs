using Rocket.Unturned.Player;
using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Inventory
{
    public class PlayerEquipEvent : Event, ICancellable
    {
        public UnturnedPlayer Player { get; }
        public PlayerEquipment Equipment { get; }
        public ItemJar Item { get; }
        public ItemAsset Asset { get; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }

        public PlayerEquipEvent(UnturnedPlayer player, PlayerEquipment equipment, ItemJar jar, ItemAsset asset,
            ref bool shouldAllow)
        {
            Player = player;
            Equipment = equipment;
            Item = jar;
            Asset = asset;
            ShouldAllow = shouldAllow;
        }
    }
}