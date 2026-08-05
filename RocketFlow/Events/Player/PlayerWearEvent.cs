using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerWearEvent : Event
    {
        public UnturnedPlayer Player { get; }

        public UnturnedPlayerEvents.Wearables Wear { get; }
        
        public ushort Id { get; }
        
        public byte? Quality { get; }

        public PlayerWearEvent(UnturnedPlayer player, UnturnedPlayerEvents.Wearables wear, ushort id, byte? quality)
        {
            Player = player;
            Wear = wear;
            Id = id;
            Quality = quality;
        }
    }
}