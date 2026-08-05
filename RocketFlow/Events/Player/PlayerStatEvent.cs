using Rocket.Unturned.Player;
using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerStatEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public EPlayerStat Stat { get; }

        public PlayerStatEvent(UnturnedPlayer player, EPlayerStat stat)
        {
            Player = player;
            Stat = stat;
        }
    }
}