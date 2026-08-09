using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Tavstal.RocketFlow.Attributes;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Player.Inventory;
using Tavstal.RocketFlow.Events.Player.Life;
using Tavstal.RocketFlow.Events.Player.Movement;

namespace Tavstal.RocketFlow.Example
{
    public class ExamplePlugin : RocketPlugin, EventListener
    {
        protected override void Load()
        {
            RocketFlow.Initialize();
            EventManager.RegisterAll(this);
            Rocket.Core.Logging.Logger.Log("RocketFlow Example Plugin loaded.");
        }

        protected override void Unload()
        {
            Rocket.Core.Logging.Logger.Log("RocketFlow Example Plugin unloaded.");
        }

        [EventHandler]
        public void OnPlayerMoved(PlayerMoveEvent e)
        {
            Rocket.Core.Logging.Logger.Log($"{e.Player.CharacterName} moved to {e.Position}");
        }
        
        [EventHandler]
        public void OnPlayerDeath(PlayerDeathEvent e)
        {
            Rocket.Core.Logging.Logger.Log($"{e.Player.CharacterName} died because of {e.Cause}");
        }

        [EventHandler(priority: EEventPriority.HIGHEST)]
        public void OnPlayerEquipHigh(PlayerEquipEvent e)
        {
            if (e.Item.item.id != 1364)
                return;

            e.ShouldAllow = false;
            e.IsCancelled = true;
            UnturnedChat.Say(e.Player, "You can't use that.");
        }

        [EventHandler]
        public void OnPlayerEquip(PlayerEquipEvent e)
        {
            Rocket.Core.Logging.Logger.Log($"{e.Player.CharacterName} equipped {e.Asset.itemName}");
        }
        
        [EventHandler(priority: EEventPriority.LOWEST, ignoreCancelled: true)]
        public void OnPlayerEquipLowest(PlayerEquipEvent e)
        {
            Rocket.Core.Logging.Logger.Log($"Did {e.Player.CharacterName} equip anything? {e.ShouldAllow}");
        }
    }
}