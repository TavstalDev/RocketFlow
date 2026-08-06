using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Zombie
{
    public class ZombieWaveEvent : Event
    {
        public bool NewWaveReady { get; }
        
        public int NewWaveIndex { get; }
        
        public ZombieWaveEvent(bool newWaveReady, int newWaveIndex)
        {
            NewWaveReady = newWaveReady;
            NewWaveIndex = newWaveIndex;
        }
    }
}
