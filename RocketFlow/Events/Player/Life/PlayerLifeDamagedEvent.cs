using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Life
{
    public class PlayerLifeDamagedEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public byte Damage { get; }
        
        public PlayerLifeDamagedEvent(UnturnedPlayer player, byte damage)
        {
            Player = player;
            Damage = damage;
        }
    }
}
