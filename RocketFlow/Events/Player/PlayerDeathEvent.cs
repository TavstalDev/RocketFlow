using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Player
{
    public class PlayerDeathEvent : Event
    {
        public UnturnedPlayer Player { get; }
        public EDeathCause Cause { get; }
        public ELimb Limb { get; }
        public CSteamID Murderer { get; }

        public PlayerDeathEvent(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            Player = player;
            Cause = cause;
            Limb = limb;
            Murderer = murderer;
        }
    }
}