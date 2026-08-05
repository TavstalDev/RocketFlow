using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Level;

namespace Tavstal.RocketFlow.RocketListeners
{
    public class RLevelListener
    {
        public RLevelListener()
        {
            Level.onLevelLoaded += OnLevelLoaded;
            Level.onLevelExited += OnLevelExited;
            Level.onLevelsRefreshed += OnLevelsRefreshed;
            Level.onPostLevelLoaded += OnPostLevelLoaded;
            Level.onPreLevelLoaded += OnPreLevelLoaded;
            Level.onPrePreLevelLoaded += OnPrePreLevelLoaded;
            Level.onSatellitePostCapture += OnSatellitePostCapture;
            Level.onSatellitePreCapture += OnSatellitePreCapture;
        }

        private void OnPrePreLevelLoaded(int level) =>
            EventManager.Fire(new LevelPrePreLoadEvent(level));

        private void OnLevelsRefreshed() =>
            EventManager.Fire(new LevelRefreshEvent());

        private void OnLevelExited() =>
            EventManager.Fire(new LevelExitEvent());

        private void OnLevelLoaded(int level) =>
            EventManager.Fire(new LevelLoadedEvent(level));

        private void OnPreLevelLoaded(int level) =>
            EventManager.Fire(new LevelPrePreLoadEvent(level));

        private void OnPostLevelLoaded(int level) =>
            EventManager.Fire(new LevelPostLoadEvent(level));
        
        private void OnSatellitePostCapture() =>
            EventManager.Fire(new LevelSatellitePostCaptureEvent());
        
        private void OnSatellitePreCapture() =>
            EventManager.Fire(new LevelSatellitePreCaptureEvent());
    }
}