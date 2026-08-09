using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Effect;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class REffectListener
    {
        public REffectListener()
        {
            EffectManager.onEffectButtonClicked += OnEffectButtonClicked;
            EffectManager.onEffectTextCommitted += OnEffectTextCommitted;
        }

        private void OnEffectButtonClicked(Player player, string buttonName) =>
            EventManager.Fire(new EffectButtonEvent(player, buttonName));
        
        private void OnEffectTextCommitted(Player player, string buttonName, string text) =>
            EventManager.Fire(new EffectTextEvent(player, buttonName, text));
    }
}