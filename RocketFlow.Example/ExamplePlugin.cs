using Rocket.Core.Plugins;
using Tavstal.RocketFlow.Attributes;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Player;

namespace Tavstal.RocketFlow.Example
{
    public class ExamplePlugin : RocketPlugin, EventListener
    {
        protected override void Load()
        {
            RocketFlow.Initialize();
            EventManager.RegisterAll(this);
            Rocket.Core.Logging.Logger.Log("RocketFlow Example Plugin loaded.");
        }

        protected override void Unload()
        {
            Rocket.Core.Logging.Logger.Log("RocketFlow Example Plugin unloaded.");
        }

        [EventHandler]
        public void OnPlayerMoved(PlayerMoveEvent e)
        {
            Rocket.Core.Logging.Logger.Log($"{e.Player.CharacterName} moved to {e.Position}");
        }
        
        [EventHandler]
        public void OnPlayerDeath(PlayerDeathEvent e)
        {
            Rocket.Core.Logging.Logger.Log($"{e.Player.CharacterName} died because of {e.Cause}");
        }
    }
}