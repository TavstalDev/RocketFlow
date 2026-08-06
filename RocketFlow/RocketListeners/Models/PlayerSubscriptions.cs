using Rocket.Unturned.Player;
using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Player;
using Tavstal.RocketFlow.Events.Player.Life;
using Tavstal.RocketFlow.Events.Player.Stat;

namespace Tavstal.RocketFlow.RocketListeners.Models
{
    public class PlayerSubscriptions
    {
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

        public PlayerSubscriptions(UnturnedPlayer player)
        {
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
        }

    }
}