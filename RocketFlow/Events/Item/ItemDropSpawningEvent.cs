using Tavstal.RocketFlow.Core;
using UnityEngine;

namespace Tavstal.RocketFlow.Events.Item
{
    public class ItemDropSpawningEvent : Event, ICancellable
    {
        public SDG.Unturned.Item Item { get; }
        
        public Vector3 Location { get; set; }
        
        public bool ShouldAllow { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public ItemDropSpawningEvent(SDG.Unturned.Item item, ref Vector3 location, ref bool shouldAllow)
        {
            Item = item;
            Location = location;
            ShouldAllow = shouldAllow;
        }
    }
}
