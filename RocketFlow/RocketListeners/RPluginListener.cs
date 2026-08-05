using System;
using Rocket.API;
using Rocket.Core.Plugins;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RPluginListener
    {
        public RPluginListener()
        {
            RocketPlugin.OnPluginLoading += OnPluginLoading;
            RocketPlugin.OnPluginUnloading += OnPluginUnloading;
        }

        private void OnPluginLoading(IRocketPlugin plugin, ref bool cancelLoading) =>
            throw new NotImplementedException();

        private void OnPluginUnloading(IRocketPlugin plugin) =>
            throw new NotImplementedException();
    }
}
