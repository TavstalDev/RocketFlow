using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerVirusEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public byte Value  { get; }
        
        public PlayerVirusEvent(UnturnedPlayer player, byte value)
        {
            Player = player;
            Value = value;
        }
    }
}