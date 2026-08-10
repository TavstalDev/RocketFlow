using SDG.Unturned;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Damage
{
    public class AnimalDamageEvent : Event, ICancellable
    {
        public DamageAnimalParameters Parameters { get; set; }
        public bool ShouldAllow { get; set; }
        public bool IsCancelled { get; set; }

        public AnimalDamageEvent(ref DamageAnimalParameters parameters, ref bool shouldAllow)
        {
            Parameters = parameters;
            ShouldAllow = shouldAllow;
        }
    }
}