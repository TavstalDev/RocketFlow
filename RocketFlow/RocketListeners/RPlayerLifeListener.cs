using System;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RPlayerLifeListener
    {
        public RPlayerLifeListener()
        {
            PlayerLife.onPlayerLifeUpdated += OnPlayerLifeUpdated;
            UnturnedPlayerEvents.OnPlayerUpdateLife += OnPlayerUpdateLife;
            UnturnedEvents.OnPlayerDamaged += OnPlayerDamaged;
            U.Events.OnPlayerConnected += OnPlayerConnected;
            U.Events.OnPlayerDisconnected += OnPlayerDisconnected;
        }

        private void OnPlayerConnected(UnturnedPlayer player)
        {
            PlayerLife life = player.Player.life;
            life.onLifeUpdated += OnLifeUpdated;
            life.onTemperatureUpdated += OnTemperatureUpdated;
            life.onOxygenUpdated += OnOxygenUpdated;
            life.onVisionUpdated += OnVisionUpdated;
            life.onDamaged += OnDamaged;

            PlayerSkills skills = player.Player.skills;
            skills.onReputationUpdated += OnReputationUpdated;
            skills.onBoostUpdated += OnBoostUpdated;
            skills.onSkillsUpdated += OnSkillsUpdated;
        }

        private void OnPlayerDisconnected(UnturnedPlayer player)
        {
            PlayerLife life = player.Player.life;
            life.onLifeUpdated -= OnLifeUpdated;
            life.onTemperatureUpdated -= OnTemperatureUpdated;
            life.onOxygenUpdated -= OnOxygenUpdated;
            life.onVisionUpdated -= OnVisionUpdated;
            life.onDamaged -= OnDamaged;

            PlayerSkills skills = player.Player.skills;
            skills.onReputationUpdated -= OnReputationUpdated;
            skills.onBoostUpdated -= OnBoostUpdated;
            skills.onSkillsUpdated -= OnSkillsUpdated;
        }

        private void OnPlayerLifeUpdated(Player player) =>
            throw new NotImplementedException();

        private void OnPlayerUpdateLife(UnturnedPlayer player, byte life) =>
            throw new NotImplementedException();

        private void OnPlayerDamaged(UnturnedPlayer player, ref EDeathCause cause, ref ELimb limb, ref UnturnedPlayer killer,
            ref Vector3 direction, ref float damage, ref float times, ref bool canDamage) =>
            throw new NotImplementedException();

        private void OnLifeUpdated(bool isDead) =>
            throw new NotImplementedException();

        private void OnTemperatureUpdated(EPlayerTemperature newTemperature) =>
            throw new NotImplementedException();

        private void OnOxygenUpdated(byte newOxygen) =>
            throw new NotImplementedException();

        private void OnVisionUpdated(bool isViewing) =>
            throw new NotImplementedException();

        private void OnDamaged(byte damage) =>
            throw new NotImplementedException();

        private void OnReputationUpdated(int newReputation) =>
            throw new NotImplementedException();

        private void OnBoostUpdated(EPlayerBoost newBoost) =>
            throw new NotImplementedException();

        private void OnSkillsUpdated() =>
            throw new NotImplementedException();
    }
}
