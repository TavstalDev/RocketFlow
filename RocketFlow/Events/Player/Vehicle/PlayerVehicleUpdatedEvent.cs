using Rocket.Unturned.Player;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player.Vehicle
{
    public class PlayerVehicleUpdatedEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public bool IsDriveable { get; }
        public ushort NewFuel { get; }
        public ushort MaxFuel { get; }
        public float NewSpeed { get; }
        public float MinSpeed { get; }
        public float MaxSpeed { get; }
        public ushort NewHealth { get; }
        public ushort MaxHealth { get; }
        public ushort NewBatteryCharge { get; }

        public PlayerVehicleUpdatedEvent(UnturnedPlayer player, bool isDriveable, ushort newFuel, ushort maxFuel, float newSpeed, 
            float minSpeed, float maxSpeed, ushort newHealth, ushort maxHealth, ushort newBatteryCharge)
        {
            Player = player;
            IsDriveable = isDriveable;
            NewFuel = newFuel;
            MaxFuel = maxFuel;
            NewSpeed = newSpeed;
            MinSpeed = minSpeed;
            MaxSpeed = maxSpeed;
            NewHealth = newHealth;
            MaxHealth = maxHealth;
            NewBatteryCharge = newBatteryCharge;
        }
    }
}