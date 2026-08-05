using Rocket.Unturned;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events;

namespace Tavstal.RocketFlow.RocketListeners
{
    public class RServerListener : Event
    {
        public RServerListener()
        {
            U.Events.OnShutdown += OnShutdown;
        }

        private void OnShutdown() =>
            EventManager.Fire(new ServerShutdownEvent());
    }
}