using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerFoodEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public byte Value  { get; }
        
        public PlayerFoodEvent(UnturnedPlayer player, byte value)
        {
            Player = player;
            Value = value;
        }
    }
}