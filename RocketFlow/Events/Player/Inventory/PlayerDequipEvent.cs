using Rocket.Unturned.Player;
using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Inventory
{
    public class PlayerDequipEvent : Event, ICancellable
    {
        public UnturnedPlayer Player { get; }
        public PlayerEquipment Equipment { get; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }
        
        public PlayerDequipEvent(UnturnedPlayer player, PlayerEquipment equipment, ref bool shouldAllow)
        {
            Player = player;
            Equipment = equipment;
            ShouldAllow = shouldAllow;
        }
    }
}