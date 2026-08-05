using System;
using SDG.Unturned;
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

        private void OnServerSpawningItemDrop(Item item, ref Vector3 location, ref bool shouldAllow) =>
            throw new NotImplementedException();

        private void OnTakeItemRequested(Player player, byte x, byte y, uint instanceID, byte to_x, byte to_y, byte to_rot, byte to_page, ItemData itemData, ref bool shouldAllow) =>
            throw new NotImplementedException();

        private void OnItemDropAdded(Transform model, InteractableItem interactableItem) =>
            throw new NotImplementedException();

        private void OnItemDropRemoved(Transform model, InteractableItem interactableItem) =>
            throw new NotImplementedException();

        private void OnConsumeRequested(Player instigatingPlayer, ItemConsumeableAsset consumeableAsset, ref bool shouldAllow) =>
            throw new NotImplementedException();

        private void OnConsumePerformed(Player instigatingPlayer, ItemConsumeableAsset consumeableAsset) =>
            throw new NotImplementedException();

        private void OnUseableChanged(PlayerEquipment equipment) =>
            throw new NotImplementedException();

        private void OnPunch(PlayerEquipment equipment, EPlayerPunch mode) =>
            throw new NotImplementedException();
    }
}
