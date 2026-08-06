using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Item
{
    public class ItemConsumedEvent : Event
    {
        public SDG.Unturned.Player InstigatingPlayer { get; }
        
        public ItemConsumeableAsset ConsumeableAsset { get; }
        
        public ItemConsumedEvent(SDG.Unturned.Player instigatingPlayer, ItemConsumeableAsset consumeableAsset)
        {
            InstigatingPlayer = instigatingPlayer;
            ConsumeableAsset = consumeableAsset;
        }
    }
}
