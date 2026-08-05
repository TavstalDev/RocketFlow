using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Barricade
{
    public class BarricadeStorageOpenEvent : Event, ICancellable
    {
        public CSteamID Instigator { get;  }
        
        public InteractableStorage Storage { get;  }
        
        public bool ShouldAllow { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public BarricadeStorageOpenEvent(CSteamID instigator, InteractableStorage storage, ref bool shouldAllow)
        {
            Instigator = instigator;
            Storage = storage;
            ShouldAllow = shouldAllow;
        }
    }
}