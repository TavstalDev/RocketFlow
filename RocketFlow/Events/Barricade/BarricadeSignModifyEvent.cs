using SDG.Unturned;
using Steamworks;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Barricade
{
    public class BarricadeSignModifyEvent : Event, ICancellable
    {
        public CSteamID Instigator { get; }
        
        public InteractableSign Sign { get; }
        
        public string Text { get; set; }
        
        public bool ShouldAllow { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public BarricadeSignModifyEvent(CSteamID instigator, InteractableSign sign, ref string text,
            ref bool shouldAllow)
        {
            Instigator = instigator;
            Sign = sign;
            Text = text;
            ShouldAllow = shouldAllow;
        }
    }
}