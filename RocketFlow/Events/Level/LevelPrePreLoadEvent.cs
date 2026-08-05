using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Level
{
    public class LevelPrePreLoadEvent : Event
    {
        public int Level { get; }
        
        public LevelPrePreLoadEvent(int level)
        {
            Level = level;
        }
    }
}