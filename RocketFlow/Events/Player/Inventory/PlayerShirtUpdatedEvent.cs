using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Inventory
{
    public class PlayerShirtUpdatedEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public ushort NewId { get; }
        public byte NewQuality { get; }
        public byte[] NewState { get; }

        public PlayerShirtUpdatedEvent(UnturnedPlayer player, ushort newId, byte newQuality, byte[] newState)
        {
            Player = player;
            NewId = newId;
            NewQuality = newQuality;
            NewState = newState;
        }
    }
}