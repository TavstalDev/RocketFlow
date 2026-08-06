using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Life
{
    public class PlayerBonesEvent: Event
    {
        public UnturnedPlayer Player { get; }
        
        public bool IsBroken { get; }

        public PlayerBonesEvent(UnturnedPlayer player, bool isBroken)
        {
            Player = player;
            IsBroken = isBroken;
        }
    }
}