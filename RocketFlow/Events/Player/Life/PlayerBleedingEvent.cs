using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Life
{
    public class PlayerBleedingEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public bool IsBleeding { get; }

        public PlayerBleedingEvent(UnturnedPlayer player, bool isBleeding)
        {
            Player = player;
            IsBleeding = isBleeding;
        }
    }
}