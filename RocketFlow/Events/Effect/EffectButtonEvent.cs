using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Effect
{
    public class EffectButtonEvent : Event, ICancellable
    {
        public SDG.Unturned.Player Player { get; }
        public string ButtonName { get; }
        public bool IsCancelled { get; set; }

        public EffectButtonEvent(SDG.Unturned.Player player, string buttonName)
        {
            Player = player;
            ButtonName = buttonName;
        }
    }
}