using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerStaminaEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public byte Value { get; }

        public PlayerStaminaEvent(UnturnedPlayer player, byte value)
        {
            Player = player;
            Value = value;
        }
    }
}