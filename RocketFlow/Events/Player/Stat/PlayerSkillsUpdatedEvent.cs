using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Stat
{
    public class PlayerSkillsUpdatedEvent : Event
    {
        public UnturnedPlayer Player { get; }

        public PlayerSkillsUpdatedEvent(UnturnedPlayer player)
        {
            Player = player;
        }
    }
}
