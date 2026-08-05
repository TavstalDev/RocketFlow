using Tavstal.RocketFlow.Core;

namespace Tavstal.RocketFlow.Events.Level
{
    public class LevelPostLoadEvent : Event
    {
        public int Level { get; }
        
        public LevelPostLoadEvent(int level)
        {
            Level = level;
        }
    }
}