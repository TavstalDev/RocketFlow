using System.Collections.Generic;
using Steamworks;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Provider
{
    public class ProviderBanEvent : Event, ICancellable
    {
        public CSteamID Instigator { get; }
        
        public CSteamID PlayerToBan { get; }
        
        public uint IpToBan { get; }
        
        public IEnumerable<byte[]> HwidsToBan { get; }
        
        public string Reason { get; set; }
        
        public uint Duration { get; set; }
        
        public bool ShouldVanillaBan { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public ProviderBanEvent(CSteamID instigator, CSteamID playerToBan, uint ipToBan,
            IEnumerable<byte[]> hwidsToBan, ref string reason, ref uint duration, ref bool shouldVanillaBan)
        {
            Instigator = instigator;
            PlayerToBan = playerToBan;
            IpToBan = ipToBan;
            HwidsToBan = hwidsToBan;
            Reason = reason;
            Duration = duration;
            ShouldVanillaBan = shouldVanillaBan;
        }
    }
}
