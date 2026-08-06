using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Life
{
    public class PlayerWaterEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public byte Value  { get; }
        
        public PlayerWaterEvent(UnturnedPlayer player, byte value)
        {
            Player = player;
            Value = value;
        }
    }
}