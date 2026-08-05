using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Barricade
{
    public class BarricadeSalvageEvent : Event, ICancellable
    {
        public BarricadeDrop Barricade { get; }
        public SteamPlayer InstigatorClient { get; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }

        public BarricadeSalvageEvent(BarricadeDrop barricade, SteamPlayer instigatorClient, ref bool shouldAllow)
        {
            Barricade = barricade;
            InstigatorClient = instigatorClient;
            ShouldAllow = shouldAllow;
        }
    }
}