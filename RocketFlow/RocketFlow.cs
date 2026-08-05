using Tavstal.RocketFlow.RocketListeners;

namespace Tavstal.RocketFlow
{
    public static class RocketFlow
    {
        private static bool _initialized;
        private static RBarricadeListener? _barricadeListener;
        private static RDamageListener? _damageListener;
        private static RLevelListener? _levelListener;
        private static RPlayerListener? _playerLifeListener;
        private static RServerListener? _serverListener;
        private static RStructureListener? _structureListener;
        private static RVehicleListener? _vehicleListener;
        
        public static void Initialize()
        {
            if (_initialized)
                return;

            try
            {
                _barricadeListener = new RBarricadeListener();
                _damageListener = new RDamageListener();
                _levelListener = new RLevelListener();
                _playerLifeListener = new RPlayerListener();
                _serverListener = new RServerListener();
                _structureListener = new RStructureListener();
                _vehicleListener = new RVehicleListener();
            }
            finally
            {
                _initialized = true;
            }
        }
    }
}