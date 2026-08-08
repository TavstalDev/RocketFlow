using Rocket.Unturned.Player;
using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Movement
{
    public class PlayerSeatedEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public bool IsDriver { get; }
        public bool InVehicle { get; }
        public bool WasVehicle { get; }
        public InteractableVehicle OldVehicle { get; }
        public InteractableVehicle NewVehicle { get; }

        public PlayerSeatedEvent(UnturnedPlayer player, bool isDriver, bool inVehicle, bool wasVehicle,
            InteractableVehicle oldVehicle, InteractableVehicle newVehicle)
        {
            Player = player;
            IsDriver = isDriver;
            InVehicle = inVehicle;
            WasVehicle = wasVehicle;
            OldVehicle = oldVehicle;
            NewVehicle = newVehicle;
        }
    }
}