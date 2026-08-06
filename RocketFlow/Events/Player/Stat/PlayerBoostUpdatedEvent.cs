using Rocket.Unturned.Player;
using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Stat
{
    public class PlayerBoostUpdatedEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public EPlayerBoost NewBoost { get; }
        
        public PlayerBoostUpdatedEvent(UnturnedPlayer player, EPlayerBoost newBoost)
        {
            Player = player;
            NewBoost = newBoost;
        }
    }
}
