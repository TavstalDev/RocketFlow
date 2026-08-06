using System;
using System.Collections.Concurrent;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Player;
using Tavstal.RocketFlow.Events.Player.Life;
using Tavstal.RocketFlow.RocketListeners.Models;
using UnityEngine;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RPlayerLifeListener
    {
        private readonly ConcurrentDictionary<string, PlayerSubscriptions> playerSubscriptions = new ConcurrentDictionary<string, PlayerSubscriptions>();
        
        public RPlayerLifeListener()
        {
            PlayerLife.onPlayerLifeUpdated += OnPlayerLifeUpdated;
            UnturnedEvents.OnPlayerDamaged += OnPlayerDamaged;
            U.Events.OnPlayerConnected += OnPlayerConnected;
            U.Events.OnPlayerDisconnected += OnPlayerDisconnected;
        }

        private void OnPlayerConnected(UnturnedPlayer player)
        {
            var subscriptions = new PlayerSubscriptions(player);
            if (!playerSubscriptions.TryAdd(player.Id, subscriptions))
                return;
            
            PlayerLife life = player.Player.life;
            life.onOxygenUpdated += subscriptions.OxygenCallback;
            life.onVisionUpdated += subscriptions.VisionCallback;
            life.onTemperatureUpdated += subscriptions.TemperatureCallback;
            life.onDamaged += subscriptions.DamagedCallback;

            PlayerSkills skills = player.Player.skills;
            skills.onReputationUpdated += subscriptions.ReputationCallback;
            skills.onBoostUpdated += subscriptions.BoostCallback;
            skills.onSkillsUpdated += subscriptions.SkillsCallback;
        }

        private void OnPlayerDisconnected(UnturnedPlayer player)
        {
            if (!playerSubscriptions.TryRemove(player.Id, out PlayerSubscriptions subscriptions))
                return;
            
            PlayerLife life = player.Player.life;
            life.onOxygenUpdated -= subscriptions.OxygenCallback;
            life.onVisionUpdated -= subscriptions.VisionCallback;
            life.onTemperatureUpdated -= subscriptions.TemperatureCallback;
            life.onDamaged -= subscriptions.DamagedCallback;

            PlayerSkills skills = player.Player.skills;
            skills.onReputationUpdated -= subscriptions.ReputationCallback;
            skills.onBoostUpdated -= subscriptions.BoostCallback;
            skills.onSkillsUpdated -= subscriptions.SkillsCallback;
        }

        private void OnPlayerLifeUpdated(Player player) =>
            EventManager.Fire(new PlayerLifeStateEvent(UnturnedPlayer.FromPlayer(player), player.life.isDead));

        private void OnPlayerDamaged(UnturnedPlayer player, ref EDeathCause cause, ref ELimb limb, ref UnturnedPlayer killer,
            ref Vector3 direction, ref float damage, ref float times, ref bool canDamage) =>
            EventManager.Fire(new PlayerDamagedEvent(player, ref cause, ref limb, ref killer, ref direction, ref damage, ref times, ref canDamage));

    }
}
