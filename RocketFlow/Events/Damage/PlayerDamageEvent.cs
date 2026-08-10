using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Damage
{
    public class PlayerDamageEvent : Event, ICancellable
    {
        public DamagePlayerParameters Parameters { get; set; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }
        
        public PlayerDamageEvent(ref DamagePlayerParameters parameters, ref bool shouldAllow)
        {
            Parameters = parameters;
            ShouldAllow = shouldAllow;
        }
    }
}