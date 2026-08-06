using Rocket.API;
using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Plugin
{
    public class PluginUnloadingEvent : Event
    {
        public IRocketPlugin Plugin { get; }
        
        public PluginUnloadingEvent(IRocketPlugin plugin)
        {
            Plugin = plugin;
        }
    }
}
