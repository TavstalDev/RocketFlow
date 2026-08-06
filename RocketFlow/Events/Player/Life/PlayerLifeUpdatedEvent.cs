using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Life
{
    public class PlayerLifeUpdatedEvent : Event
    {
        public SDG.Unturned.Player Player { get; }
        
        public PlayerLifeUpdatedEvent(SDG.Unturned.Player player)
        {
            Player = player;
        }
    }
}
