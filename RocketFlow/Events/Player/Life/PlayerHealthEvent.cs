using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Life
{
    public class PlayerHealthEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public byte Value  { get; }
        
        public PlayerHealthEvent(UnturnedPlayer player, byte value)
        {
            Player = player;
            Value = value;
        }
    }
}