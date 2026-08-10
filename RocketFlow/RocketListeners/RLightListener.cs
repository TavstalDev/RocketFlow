using SDG.Unturned;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Lighting;

namespace Tavstal.RocketFlow.RocketListeners
{
    public class RLightListener
    {
        public RLightListener()
        {
            LightingManager.onDayNightUpdated += OnDayNightUpdated;
            LightingManager.onMoonUpdated += OnMoonUpdated;
            LightingManager.onRainUpdated += OnRainUpdated;
            LightingManager.onSnowUpdated += OnSnowUpdated;
            LightingManager.onTimeOfDayChanged += OnTimeOfDayChanged;
        }

        private void OnDayNightUpdated(bool isDaytime) =>
            EventManager.Fire(new LightDayNightEvent(isDaytime));

        private void OnMoonUpdated(bool isFullMoon) =>
            EventManager.Fire(new LightMoonEvent(isFullMoon));

        private void OnTimeOfDayChanged() =>
            EventManager.Fire(new LightTimeEvent());

        private void OnRainUpdated(ELightingRain rain) =>
            EventManager.Fire(new LightRainEvent(rain));

        private void OnSnowUpdated(ELightingSnow snow) =>
            EventManager.Fire(new LightSnowEvent(snow));
    }
}