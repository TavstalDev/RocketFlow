using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Item
{
    public class EquipmentPunchEvent : Event
    {
        public PlayerEquipment Equipment { get; }
        
        public EPlayerPunch Mode { get; }
        
        public EquipmentPunchEvent(PlayerEquipment equipment, EPlayerPunch mode)
        {
            Equipment = equipment;
            Mode = mode;
        }
    }
}
