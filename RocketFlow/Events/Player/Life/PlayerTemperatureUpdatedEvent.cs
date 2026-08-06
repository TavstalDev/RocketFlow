using Rocket.Unturned.Player;
using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Life
{
    public class PlayerTemperatureUpdatedEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public EPlayerTemperature NewTemperature { get; }
        
        public PlayerTemperatureUpdatedEvent(UnturnedPlayer player, EPlayerTemperature newTemperature)
        {
            Player = player;
            NewTemperature = newTemperature;
        }
    }
}
