using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Zombie;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RZombieAnimalListener
    {
        public RZombieAnimalListener()
        {
            ZombieManager.onWaveUpdated += OnWaveUpdated;
        }

        private void OnWaveUpdated(bool newWaveReady, int newWaveIndex) =>
            EventManager.Fire(new ZombieWaveEvent(newWaveReady, newWaveIndex));
    }
}
