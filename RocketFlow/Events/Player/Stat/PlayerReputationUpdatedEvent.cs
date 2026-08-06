using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Stat
{
    public class PlayerReputationUpdatedEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public int NewReputation { get; }
        
        public PlayerReputationUpdatedEvent(UnturnedPlayer player, int newReputation)
        {
            Player = player;
            NewReputation = newReputation;
        }
    }
}
