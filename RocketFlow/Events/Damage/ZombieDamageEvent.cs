using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Damage
{
    public class ZombieDamageEvent : Event, ICancellable
    {
        public DamageZombieParameters Parameters { get; set; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }
        
        public ZombieDamageEvent(ref DamageZombieParameters parameters, ref bool shouldAllow)
        {
            Parameters = parameters;
            ShouldAllow = shouldAllow;
        }
    }
}