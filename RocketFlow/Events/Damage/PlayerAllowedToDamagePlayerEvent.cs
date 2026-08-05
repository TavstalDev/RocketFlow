using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Damage
{
    public class PlayerAllowedToDamagePlayerEvent : Event, ICancellable
    {
        public SDG.Unturned.Player Instigator { get; }
        public SDG.Unturned.Player Victim { get; }
        public bool IsAllowed { get; set; }
        public bool IsCancelled { get; set; }
        
        public PlayerAllowedToDamagePlayerEvent(SDG.Unturned.Player instigator, SDG.Unturned.Player victim,
            ref bool isAllowed)
        {
            Instigator = instigator;
            Victim = victim;
            IsAllowed = isAllowed;
        }
    }
}