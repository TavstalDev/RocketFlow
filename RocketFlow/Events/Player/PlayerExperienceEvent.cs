using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerExperienceEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public uint Value { get;  }

        public PlayerExperienceEvent(UnturnedPlayer player, uint value)
        {
            Player = player;
            Value = value;
        }
    }
}