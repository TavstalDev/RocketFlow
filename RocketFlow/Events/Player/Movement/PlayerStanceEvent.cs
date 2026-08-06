using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Movement
{
    public class PlayerStanceEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public byte Stance { get; }

        public PlayerStanceEvent(UnturnedPlayer player, byte stance)
        {
            Player = player;
            Stance = stance;
        }
    }
}