using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Level
{
    public class LevelPreLoadEvent : Event
    {
        public int Level { get; }
        
        public LevelPreLoadEvent(int level)
        {
            Level = level;
        }
    }
}