using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Item;
using UnityEngine;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RItemListener
    {
        public RItemListener()
        {
            ItemManager.onServerSpawningItemDrop += OnServerSpawningItemDrop;
            ItemManager.onTakeItemRequested += OnTakeItemRequested;
            ItemManager.onItemDropAdded += OnItemDropAdded;
            ItemManager.onItemDropRemoved += OnItemDropRemoved;
            UseableConsumeable.onConsumeRequested += OnConsumeRequested;
            UseableConsumeable.onConsumePerformed += OnConsumePerformed;
            PlayerEquipment.OnUseableChanged_Global += OnUseableChanged;
            PlayerEquipment.OnPunch_Global += OnPunch;
        }

        private void OnServerSpawningItemDrop(Item item, ref Vector3 location, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new ItemDropSpawningEvent(item, ref location, ref shouldAllow));
            location = e.Location;
            shouldAllow = e.ShouldAllow;
        }

        private void OnTakeItemRequested(Player player, byte x, byte y, uint instanceID, byte to_x, byte to_y, byte to_rot, byte to_page, ItemData itemData, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new ItemTakeEvent(player, x, y, instanceID, to_x, to_y, to_rot, to_page, itemData, ref shouldAllow));
            shouldAllow = e.ShouldAllow;
        }

        private void OnItemDropAdded(Transform model, InteractableItem interactableItem) =>
            EventManager.Fire(new ItemDropAddedEvent(model, interactableItem));

        private void OnItemDropRemoved(Transform model, InteractableItem interactableItem) =>
            EventManager.Fire(new ItemDropRemovedEvent(model, interactableItem));

        private void OnConsumeRequested(Player instigatingPlayer, ItemConsumeableAsset consumeableAsset, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new ItemConsumeEvent(instigatingPlayer, consumeableAsset, ref shouldAllow));
            shouldAllow = e.ShouldAllow;
        }

        private void OnConsumePerformed(Player instigatingPlayer, ItemConsumeableAsset consumeableAsset) =>
            EventManager.Fire(new ItemConsumedEvent(instigatingPlayer, consumeableAsset));

        private void OnUseableChanged(PlayerEquipment equipment) =>
            EventManager.Fire(new EquipmentUseableChangedEvent(equipment));

        private void OnPunch(PlayerEquipment equipment, EPlayerPunch mode) =>
            EventManager.Fire(new EquipmentPunchEvent(equipment, mode));
    }
}
