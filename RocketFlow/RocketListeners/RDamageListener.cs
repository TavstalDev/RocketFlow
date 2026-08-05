using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Damage;

namespace Tavstal.RocketFlow.RocketListeners
{
    public class RDamageListener
    {
        public RDamageListener()
        {
            DamageTool.damageAnimalRequested += OnDamageAnimalRequested;
            DamageTool.damageZombieRequested += OnDamageZombieRequested;
            DamageTool.damagePlayerRequested += OnDamagePlayerRequested;
            DamageTool.onPlayerAllowedToDamagePlayer += PlayerAllowedToDamagePlayer;
        }

        private void OnDamageAnimalRequested(ref DamageAnimalParameters parameters, ref bool shouldAllow) =>
            EventManager.Fire(new AnimalDamageEvent(ref parameters, ref shouldAllow));

        private void OnDamageZombieRequested(ref DamageZombieParameters parameters, ref bool shouldAllow) =>
            EventManager.Fire(new ZombieDamageEvent(ref parameters, ref shouldAllow));
        
        private void OnDamagePlayerRequested(ref DamagePlayerParameters parameters, ref bool shouldAllow) =>
            EventManager.Fire(new PlayerDamageEvent(ref parameters, ref shouldAllow));

        private void PlayerAllowedToDamagePlayer(SDG.Unturned.Player instigator, SDG.Unturned.Player victim, ref bool isAllowed) =>
            EventManager.Fire(new PlayerAllowedToDamagePlayerEvent(instigator, victim, ref isAllowed));
    }
}