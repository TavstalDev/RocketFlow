using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Damage;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RDamageListener
    {
        public RDamageListener()
        {
            DamageTool.damageAnimalRequested += OnDamageAnimalRequested;
            DamageTool.damageZombieRequested += OnDamageZombieRequested;
            DamageTool.damagePlayerRequested += OnDamagePlayerRequested;
            DamageTool.onPlayerAllowedToDamagePlayer += PlayerAllowedToDamagePlayer;
        }

        private void OnDamageAnimalRequested(ref DamageAnimalParameters parameters, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new AnimalDamageEvent(ref parameters, ref shouldAllow));
            shouldAllow = e.ShouldAllow;
        }

        private void OnDamageZombieRequested(ref DamageZombieParameters parameters, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new ZombieDamageEvent(ref parameters, ref shouldAllow));
            shouldAllow = e.ShouldAllow;
        }
        
        private void OnDamagePlayerRequested(ref DamagePlayerParameters parameters, ref bool shouldAllow)
        {
            var e = EventManager.Fire(new PlayerDamageEvent(ref parameters, ref shouldAllow));
            shouldAllow = e.ShouldAllow;
        }

        private void PlayerAllowedToDamagePlayer(Player instigator, Player victim, ref bool isAllowed)
        {
            var e = EventManager.Fire(new PlayerAllowedToDamagePlayerEvent(instigator, victim, ref isAllowed));
            isAllowed = e.IsAllowed;
        }
    }
}