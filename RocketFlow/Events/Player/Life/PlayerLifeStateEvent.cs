using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Life
{
    public class PlayerLifeStateEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public bool IsDead { get; }
        
        public PlayerLifeStateEvent(UnturnedPlayer player, bool isDead)
        {
            Player = player;
            IsDead = isDead;
        }
    }
}
