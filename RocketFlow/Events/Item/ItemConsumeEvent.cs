using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Item
{
    public class ItemConsumeEvent : Event, ICancellable
    {
        public SDG.Unturned.Player InstigatingPlayer { get; }
        
        public ItemConsumeableAsset ConsumeableAsset { get; }
        
        public bool ShouldAllow { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public ItemConsumeEvent(SDG.Unturned.Player instigatingPlayer, ItemConsumeableAsset consumeableAsset,
            ref bool shouldAllow)
        {
            InstigatingPlayer = instigatingPlayer;
            ConsumeableAsset = consumeableAsset;
            ShouldAllow = shouldAllow;
        }
    }
}
