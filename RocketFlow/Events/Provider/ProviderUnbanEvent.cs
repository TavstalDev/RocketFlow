using Steamworks;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Provider
{
    public class ProviderUnbanEvent : Event, ICancellable
    {
        public CSteamID Instigator { get; }
        
        public CSteamID PlayerToUnban { get; }
        
        public bool ShouldVanillaUnban { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public ProviderUnbanEvent(CSteamID instigator, CSteamID playerToUnban, ref bool shouldVanillaUnban)
        {
            Instigator = instigator;
            PlayerToUnban = playerToUnban;
            ShouldVanillaUnban = shouldVanillaUnban;
        }
    }
}
