using Rocket.API;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Plugin
{
    public class PluginLoadingEvent : Event, ICancellable
    {
        public IRocketPlugin Plugin { get; }
        
        public bool CancelLoading { get; set; }
        
        public bool IsCancelled { get; set; }
        
        public PluginLoadingEvent(IRocketPlugin plugin, ref bool cancelLoading)
        {
            Plugin = plugin;
            CancelLoading = cancelLoading;
        }
    }
}
