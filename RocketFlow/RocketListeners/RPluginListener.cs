using Rocket.API;
using Rocket.Core.Plugins;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Plugin;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RPluginListener
    {
        public RPluginListener()
        {
            RocketPlugin.OnPluginLoading += OnPluginLoading;
            RocketPlugin.OnPluginUnloading += OnPluginUnloading;
        }

        private void OnPluginLoading(IRocketPlugin plugin, ref bool cancelLoading)
        {
            var e = EventManager.Fire(new PluginLoadingEvent(plugin, ref cancelLoading));
            cancelLoading = e.CancelLoading;
        }

        private void OnPluginUnloading(IRocketPlugin plugin) =>
            EventManager.Fire(new PluginUnloadingEvent(plugin));
    }
}
