using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Item
{
    public class ItemDropAddedEvent : Event
    {
        public Transform Model { get; }
        
        public InteractableItem InteractableItem { get; }
        
        public ItemDropAddedEvent(Transform model, InteractableItem interactableItem)
        {
            Model = model;
            InteractableItem = interactableItem;
        }
    }
}
