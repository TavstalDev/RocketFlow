namespace Tavstal.RocketFlow.Core
{
    public interface ICancellable
    {
        bool IsCancelled { get; set; }
    }
}