using System;
using SDG.Unturned;

namespace Tavstal.RocketFlow.RocketListeners
{
    internal class RZombieAnimalListener
    {
        public RZombieAnimalListener()
        {
            ZombieManager.onWaveUpdated += OnWaveUpdated;
        }

        private void OnWaveUpdated(bool newWaveReady, int newWaveIndex) =>
            throw new NotImplementedException();
    }
}
