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
    internal class RPlayerSubscriptionsListener
    {
        private readonly ConcurrentDictionary<string, PlayerSubscriptions> playerSubscriptions = new ConcurrentDictionary<string, PlayerSubscriptions>();
        
        public RPlayerSubscriptionsListener()
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
            
            PlayerMovement movement = player.Player.movement;
            movement.onLanded += subscriptions.LandedCallback;
            movement.onSeated += subscriptions.SeatedCallback;
            movement.onVehicleUpdated += subscriptions.VehicleUpdatedCallback;
            
            PlayerInventory inventory = player.Player.inventory;
            inventory.onDropItemRequested += subscriptions.DropItemRequestedCallback;
            inventory.onInventoryStateUpdated += subscriptions.InventoryStateUpdatedCallback;
            inventory.onInventoryStored += subscriptions.InventoryStoredCallback;
            
            PlayerEquipment equipment = player.Player.equipment;
            equipment.onEquipRequested += subscriptions.EquipRequestedCallback;
            equipment.onDequipRequested += subscriptions.DequipRequestedCallback;
            
            PlayerClothing clothing = player.Player.clothing;
            clothing.onHatUpdated += subscriptions.HatUpdatedCallback;
            clothing.onShirtUpdated += subscriptions.ShirtUpdatedCallback;
            clothing.onPantsUpdated += subscriptions.PantsUpdatedCallback;
            clothing.onVestUpdated += subscriptions.VestUpdatedCallback;
            clothing.onMaskUpdated += subscriptions.MaskUpdatedCallback;
            clothing.onGlassesUpdated += subscriptions.GlassesUpdatedCallback;
            clothing.onBackpackUpdated += subscriptions.BackpackUpdatedCallback;
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
            ref Vector3 direction, ref float damage, ref float times, ref bool canDamage)
        {
            var e = EventManager.Fire(new PlayerDamagedEvent(player, ref cause, ref limb, ref killer, ref direction, ref damage, ref times, ref canDamage));
            cause = e.Cause;
            limb = e.Limb;
            killer = e.Killer;
            direction = e.Direction;
            damage = e.Damage;
            times = e.Times;
            canDamage = e.CanDamage;
        }

    }
}
