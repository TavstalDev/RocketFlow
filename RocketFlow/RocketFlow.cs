using Tavstal.RocketFlow.RocketListeners;

namespace Tavstal.RocketFlow
{
    public static class RocketFlow
    {
        private static bool _initialized;
        private static RBarricadeListener? _barricadeListener;
        private static RCraftListener? _craftListener;
        private static RDamageListener? _damageListener;
        private static RItemListener? _itemListener;
        private static RLevelListener? _levelListener;
        private static RPlayerSubscriptionsListener? _playerLifeListener;
        private static RPlayerListener? _playerListener;
        private static RPluginListener? _pluginListener;
        private static RProviderListener? _serverListener;
        private static RStructureListener? _structureListener;
        private static RVehicleListener? _vehicleListener;
        private static RWorldListener? _worldListener;
        private static RZombieAnimalListener? _zombieAnimalListener;
        
        public static void Initialize()
        {
            if (_initialized)
                return;

            try
            {
                _barricadeListener = new RBarricadeListener();
                _craftListener = new RCraftListener();
                _damageListener = new RDamageListener();
                _itemListener = new RItemListener();
                _levelListener = new RLevelListener();
                _playerLifeListener = new RPlayerSubscriptionsListener();
                _playerListener = new RPlayerListener();
                _pluginListener = new RPluginListener();
                _serverListener = new RProviderListener();
                _structureListener = new RStructureListener();
                _vehicleListener = new RVehicleListener();
                _worldListener = new RWorldListener();
                _zombieAnimalListener = new RZombieAnimalListener();
            }
            finally
            {
                _initialized = true;
            }
        }
    }
}