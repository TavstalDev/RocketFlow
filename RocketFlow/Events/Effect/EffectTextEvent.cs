using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Effect
{
    public class EffectTextEvent : Event, ICancellable
    {
        public SDG.Unturned.Player Player { get; }
        public string ButtonName { get; }
        public string Text { get; }
        public bool IsCancelled { get; set; }

        public EffectTextEvent(SDG.Unturned.Player player, string buttonName, string text)
        {
            Player = player;
            ButtonName = buttonName;
            Text = text;
        }
    }
}