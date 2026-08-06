using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Item
{
    public class ItemTakeEvent : Event, ICancellable
    {
        public SDG.Unturned.Player Player { get; }
        
        public byte X { get; }
        
        public byte Y { get; }
        
        public uint InstanceID { get; }
        
        public byte ToX { get; }
        
        public byte ToY { get; }
        
        public byte ToRotation { get; }
        
        public byte ToPage { get; }
        
        public ItemData ItemData { get; }
        
        public bool ShouldAllow { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public ItemTakeEvent(SDG.Unturned.Player player, byte x, byte y, uint instanceID, byte toX, byte toY,
            byte toRotation, byte toPage, ItemData itemData, ref bool shouldAllow)
        {
            Player = player;
            X = x;
            Y = y;
            InstanceID = instanceID;
            ToX = toX;
            ToY = toY;
            ToRotation = toRotation;
            ToPage = toPage;
            ItemData = itemData;
            ShouldAllow = shouldAllow;
        }
    }
}
