using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Item
{
    public class EquipmentUseableChangedEvent : Event
    {
        public PlayerEquipment Equipment { get; }
        
        public EquipmentUseableChangedEvent(PlayerEquipment equipment)
        {
            Equipment = equipment;
        }
    }
}
