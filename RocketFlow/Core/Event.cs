using System;

namespace Tavstal.RocketFlow.Core
{
    public abstract class Event
    {
        public DateTime FiredAtUtc { get; } = DateTime.UtcNow;
    }
}