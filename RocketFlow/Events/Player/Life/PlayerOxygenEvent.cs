using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Life
{
    public class PlayerOxygenEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public byte NewOxygen { get; }
        
        public PlayerOxygenEvent(UnturnedPlayer player, byte newOxygen)
        {
            Player = player;
            NewOxygen = newOxygen;
        }
    }
}
