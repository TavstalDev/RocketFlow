using Rocket.Unturned.Player;
using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Player;
using Tavstal.RocketFlow.Events.Player.Inventory;
using Tavstal.RocketFlow.Events.Player.Life;
using Tavstal.RocketFlow.Events.Player.Movement;
using Tavstal.RocketFlow.Events.Player.Stat;
using Tavstal.RocketFlow.Events.Player.Vehicle;

namespace Tavstal.RocketFlow.RocketListeners.Models
{
    public class PlayerSubscriptions
    {
        private UnturnedPlayer _player { get; }
        
        public LifeUpdated LifeCallback { get; private set; }
        public OxygenUpdated OxygenCallback { get; private set; }
        public TemperatureUpdated TemperatureCallback { get; private set; }
        public SafetyUpdated SafetyCallback { get; private set; }
        public RadiationUpdated RadiationCallback { get; private set; }
        public VisionUpdated VisionCallback { get; private set; }
        public Damaged DamagedCallback { get; private set; }
        public ReputationUpdated ReputationCallback { get; private set; }
        public BoostUpdated BoostCallback { get; private set; }
        public SkillsUpdated SkillsCallback { get; private set; }
        
        public Landed LandedCallback { get; private set; }
        public Seated SeatedCallback { get; private set; }
        public VehicleUpdated VehicleUpdatedCallback { get; private set; }
        
        public DropItemRequestHandler DropItemRequestedCallback { get; private set; }
        public InventoryStateUpdated InventoryStateUpdatedCallback { get; private set; }
        public InventoryStored InventoryStoredCallback { get; private set; }
        
        public PlayerEquipRequestHandler EquipRequestedCallback { get; private set; }
        public PlayerDequipRequestHandler DequipRequestedCallback { get; private set; }
        
        public HatUpdated HatUpdatedCallback { get; private set; }
        public ShirtUpdated ShirtUpdatedCallback { get; private set; }
        public PantsUpdated PantsUpdatedCallback { get; private set; }
        public VestUpdated VestUpdatedCallback { get; private set; }
        public BackpackUpdated BackpackUpdatedCallback { get; private set; }
        public GlassesUpdated GlassesUpdatedCallback { get; private set; }
        public MaskUpdated MaskUpdatedCallback { get; private set; }
        
        public Hurt HurtCallback { get; private set; }

        public PlayerSubscriptions(UnturnedPlayer player)
        {
            _player = player;
            
            LifeCallback = isDead => EventManager.Fire(new PlayerLifeStateEvent(player, isDead));
            OxygenCallback = oxygen => EventManager.Fire(new PlayerOxygenEvent(player, oxygen));
            TemperatureCallback = newTemperature => EventManager.Fire(new PlayerTemperatureUpdatedEvent(player, newTemperature));
            SafetyCallback = isSafe => EventManager.Fire(new PlayerSafezoneUpdatedEvent(player, isSafe));
            RadiationCallback = isRadio => EventManager.Fire(new PlayerDeadzoneUpdatedEvent(player, isRadio));
            VisionCallback = isViewing => EventManager.Fire(new PlayerVisionUpdatedEvent(player, isViewing));
            DamagedCallback = damage => EventManager.Fire(new PlayerLifeDamagedEvent(player, damage));
            ReputationCallback = newReputation => EventManager.Fire(new PlayerReputationUpdatedEvent(player, newReputation));
            BoostCallback = newBoost => EventManager.Fire(new PlayerBoostUpdatedEvent(player, newBoost));
            SkillsCallback = () => EventManager.Fire(new PlayerSkillsUpdatedEvent(player));
            
            LandedCallback = velocity => EventManager.Fire(new PlayerLandedEvent(player, velocity));
            SeatedCallback = (isDriver, inVehicle, wasVehicle, oldVehicle, newVehicle) => EventManager.Fire(new PlayerSeatedEvent(player, isDriver, inVehicle, wasVehicle, oldVehicle, newVehicle));
            VehicleUpdatedCallback = (isDriveable, newFuel, maxFuel, newSpeed, minSpeed, maxSpeed, newHealth, maxHealth, newBatteryCharge) => 
                EventManager.Fire(new PlayerVehicleUpdatedEvent(player, isDriveable, newFuel, maxFuel, newSpeed,minSpeed, maxSpeed, newHealth,maxHealth,newBatteryCharge));
            
            DropItemRequestedCallback = HandleDropItemRequest;
            InventoryStateUpdatedCallback = () => EventManager.Fire(new PlayerInventoryStateUpdatedEvent(player));
            InventoryStoredCallback = () => EventManager.Fire(new PlayerInventoryStoredEvent(player));
            
            EquipRequestedCallback = HandleEquipRequest;
            DequipRequestedCallback = HandleDequipRequest;
            
            HatUpdatedCallback = (newId, newQuality, newState) => EventManager.Fire(new PlayerHatUpdatedEvent(player, newId, newQuality, newState));
            ShirtUpdatedCallback = (newId, newQuality, newState) => EventManager.Fire(new PlayerShirtUpdatedEvent(player, newId, newQuality, newState));
            PantsUpdatedCallback = (newId, newQuality, newState) => EventManager.Fire(new PlayerPantsUpdatedEvent(player, newId, newQuality, newState));
            VestUpdatedCallback = (newId, newQuality, newState) => EventManager.Fire(new PlayerVestUpdatedEvent(player, newId, newQuality, newState));
            BackpackUpdatedCallback = (newId, newQuality, newState) => EventManager.Fire(new PlayerBackpackUpdatedEvent(player, newId, newQuality, newState));
            GlassesUpdatedCallback = (newId, newQuality, newState) => EventManager.Fire(new PlayerGlassesUpdatedEvent(player, newId, newQuality, newState));
            MaskUpdatedCallback = (newId, newQuality, newState) => EventManager.Fire(new PlayerMaskUpdatedEvent(player, newId, newQuality, newState));

            HurtCallback = (victim, damage, force,cause, limb, killer) => EventManager.Fire(new PlayerHurtEvent(victim, damage, force, cause, limb, killer));
        }

        void HandleDropItemRequest(PlayerInventory inventory, Item item, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new PlayerInventoryDropEvent(_player, inventory, item, ref shouldAllow));
            shouldAllow = e.ShouldAllow;
        }

        void HandleEquipRequest(PlayerEquipment equipment, ItemJar jar, ItemAsset asset, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new PlayerEquipEvent(_player, equipment, jar, asset, ref shouldAllow));
            shouldAllow = e.ShouldAllow;
        }

        void HandleDequipRequest(PlayerEquipment equipment, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new PlayerDequipEvent(_player, equipment, ref shouldAllow));
            shouldAllow = e.ShouldAllow;
        }
    }
}
