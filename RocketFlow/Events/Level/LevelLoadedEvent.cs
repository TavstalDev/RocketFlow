using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Level
{
    public class LevelLoadedEvent : Event
    {
        public int Level { get; }
        
        public LevelLoadedEvent(int level)
        {
            Level = level;
        }
    }
}