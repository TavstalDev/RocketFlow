using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerGestureEvent : Event
    {
        public UnturnedPlayer Player { get; }
        
        public UnturnedPlayerEvents.PlayerGesture Gesture { get; }

        public PlayerGestureEvent(UnturnedPlayer player, UnturnedPlayerEvents.PlayerGesture gesture)
        {
            Player = player;
            Gesture = gesture;
        }
    }
}