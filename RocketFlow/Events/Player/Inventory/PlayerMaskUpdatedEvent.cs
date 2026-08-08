using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Inventory
{
    public class PlayerMaskUpdatedEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public ushort NewId { get; }
        public ushort NewQuality { get; }
        public byte[] NewState { get; }
        
        public PlayerMaskUpdatedEvent(UnturnedPlayer player, ushort newId, byte newQuality, byte[] newState)
        {
            Player = player;
            NewId = newId;
            NewQuality = newQuality;
            NewState = newState;
        }
    }
}