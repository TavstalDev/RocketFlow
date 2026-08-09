using Rocket.Unturned;
using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Player;
using Tavstal.RocketFlow.Events.Player.Inventory;
using Tavstal.RocketFlow.Events.Player.Life;
using Tavstal.RocketFlow.Events.Player.Movement;
using Tavstal.RocketFlow.Events.Player.Stat;
using UnityEngine;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RPlayerListener
    {
        public RPlayerListener()
        {
            U.Events.OnBeforePlayerConnected += OnBeforePlayerConnected;
            U.Events.OnPlayerConnected += OnPlayerConnected;
            U.Events.OnPlayerDisconnected += OnPlayerDisconnected;
            UnturnedPlayerEvents.OnPlayerUpdatePosition += OnPlayerUpdatePosition;
            UnturnedPlayerEvents.OnPlayerUpdateBleeding += OnPlayerUpdateBleeding;
            UnturnedPlayerEvents.OnPlayerUpdateBroken += OnPlayerUpdateBroken;
            UnturnedPlayerEvents.OnPlayerDeath += OnPlayerDeath;
            UnturnedPlayerEvents.OnPlayerDead += OnPlayerDead;
            UnturnedPlayerEvents.OnPlayerUpdateFood += OnPlayerUpdateFood;
            UnturnedPlayerEvents.OnPlayerUpdateHealth += OnPlayerUpdateHealth;
            UnturnedPlayerEvents.OnPlayerUpdateVirus += OnPlayerUpdateVirus;
            UnturnedPlayerEvents.OnPlayerUpdateWater += OnPlayerUpdateWater;
            UnturnedPlayerEvents.OnPlayerUpdateGesture += OnPlayerUpdateGesture;
            UnturnedPlayerEvents.OnPlayerUpdateStance += OnPlayerUpdateStance;
            UnturnedPlayerEvents.OnPlayerRevive += OnPlayerRevive;
            UnturnedPlayerEvents.OnPlayerUpdateStat += OnPlayerUpdateStat;
            UnturnedPlayerEvents.OnPlayerUpdateExperience += OnPlayerUpdateExperience;
            UnturnedPlayerEvents.OnPlayerUpdateStamina += OnPlayerUpdateStamina;
            UnturnedPlayerEvents.OnPlayerInventoryUpdated += OnPlayerInventoryUpdated;
            UnturnedPlayerEvents.OnPlayerInventoryResized += OnPlayerInventoryResized;
            UnturnedPlayerEvents.OnPlayerInventoryRemoved += OnPlayerInventoryRemoved;
            UnturnedPlayerEvents.OnPlayerInventoryAdded += OnPlayerInventoryAdded;
            UnturnedPlayerEvents.OnPlayerChatted += OnPlayerChatted;
            UnturnedPlayerEvents.OnPlayerWear += OnPlayerWear;
        }

        private void OnBeforePlayerConnected(UnturnedPlayer player) =>
            EventManager.Fire(new PlayerPreConnectEvent(player));
        
        private void OnPlayerConnected(UnturnedPlayer player) =>
            EventManager.Fire(new PlayerConnectEvent(player));
        
        private void OnPlayerDisconnected(UnturnedPlayer player) =>
            EventManager.Fire(new PlayerDisconnectEvent(player));
        

        public void OnPlayerUpdatePosition(UnturnedPlayer player, Vector3 position) =>
            EventManager.Fire(new PlayerMoveEvent(player, position));
        

        public void OnPlayerUpdateBleeding(UnturnedPlayer player, bool bleeding) =>
            EventManager.Fire(new PlayerBleedingEvent(player, bleeding));
        

        public void OnPlayerUpdateBroken(UnturnedPlayer player, bool broken) =>
            EventManager.Fire(new PlayerBonesEvent(player, broken));

        public void OnPlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer) =>
            EventManager.Fire(new PlayerDeathEvent(player, cause, limb, murderer));

        public void OnPlayerDead(UnturnedPlayer player, Vector3 position) =>
            EventManager.Fire(new PlayerDeadEvent(player, position));

        public void OnPlayerUpdateFood(UnturnedPlayer player, byte food) =>
            EventManager.Fire(new PlayerFoodEvent(player, food));

        public void OnPlayerUpdateHealth(UnturnedPlayer player, byte health) =>
            EventManager.Fire(new PlayerHealthEvent(player, health));

        public void OnPlayerUpdateVirus(UnturnedPlayer player, byte virus) =>
            EventManager.Fire(new PlayerVirusEvent(player, virus));

        public void OnPlayerUpdateWater(UnturnedPlayer player, byte water) =>
            EventManager.Fire(new PlayerWaterEvent(player, water));

        public void OnPlayerUpdateGesture(UnturnedPlayer player, UnturnedPlayerEvents.PlayerGesture gesture) =>
            EventManager.Fire(new PlayerGestureEvent(player, gesture));

        public void OnPlayerUpdateStance(UnturnedPlayer player, byte stance) => 
            EventManager.Fire(new PlayerStanceEvent(player, stance));

        public void OnPlayerRevive(UnturnedPlayer player, Vector3 position, byte angle) =>
            EventManager.Fire(new PlayerReviveEvent(player, position, angle));

        public void OnPlayerUpdateStat(UnturnedPlayer player, EPlayerStat stat) =>
            EventManager.Fire(new PlayerStatEvent(player, stat));
        

        public void OnPlayerUpdateExperience(UnturnedPlayer player, uint experience) =>
            EventManager.Fire(new PlayerExperienceEvent(player, experience));
        

        public void OnPlayerUpdateStamina(UnturnedPlayer player, byte stamina) =>
            EventManager.Fire(new PlayerStaminaEvent(player, stamina));

        public void OnPlayerInventoryUpdated(UnturnedPlayer player, InventoryGroup inventoryGroup, byte inventoryIndex,
            ItemJar item) =>
            EventManager.Fire(new PlayerInventoryEvent(player, inventoryGroup, inventoryIndex, item));
        
        public void OnPlayerInventoryResized(UnturnedPlayer player, InventoryGroup inventoryGroup, byte x, byte y) =>
            EventManager.Fire(new PlayerInventoryResizeEvent(player, inventoryGroup, x, y));


        public void OnPlayerInventoryRemoved(UnturnedPlayer player, InventoryGroup inventoryGroup, byte inventoryIndex,
            ItemJar itemJar) =>
            EventManager.Fire(new PlayerInventoryRemoveEvent(player, inventoryGroup, inventoryIndex, itemJar));

        public void OnPlayerInventoryAdded(UnturnedPlayer player, InventoryGroup inventoryGroup, byte inventoryIndex,
            ItemJar itemJar) =>
            EventManager.Fire(new PlayerInventoryAddEvent(player, inventoryGroup, inventoryIndex, itemJar));

        public void OnPlayerWear(UnturnedPlayer player, UnturnedPlayerEvents.Wearables wear, ushort id, byte? quality) =>
            EventManager.Fire(new PlayerWearEvent(player, wear, id, quality));
        
        public void OnPlayerChatted(UnturnedPlayer player, ref Color color, string message, EChatMode chatMode,
            ref bool cancel)
        {
            var e = EventManager.Fire(new PlayerChatEvent(player, ref color, message, chatMode, ref cancel));
            color = e.Color;
            cancel = e.Cancel;
        }
    }
}