namespace WeatherDataLib
{
    public class WeatherData
    {
        private List<IClientObserver> _clientObservers = new List<IClientObserver>();

        // note internal access mods so they are accessible in ContextObject
        internal double _temp;
        internal double _humidity;
        internal double _pressure;

        private ISensor _sensor;

        public Dispatcher Dispatcher { get; } = new Dispatcher();

        public WeatherData()
        {
            _sensor = new Sensor();
        }

        public WeatherData(ISensor sensor)
        {
            _sensor = sensor;
        }

        #region Original observer in WeatherStation
        public void RegisterObserver(IClientObserver observer)
        {
            _clientObservers.Add(observer);
        }

        public void RemoveObserver(IClientObserver observer)
        {
            _clientObservers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (IClientObserver observer in _clientObservers)
                observer.UpdateReadings(_temp, _humidity, _pressure);
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }
        #endregion

        private void ReadAndSendSensorData()
        {
            // "read" new data from sensors
            _temp = _sensor.ReadTempSensor();
            _humidity = _sensor.ReadHumidSensor();
            _pressure = _sensor.ReadPressureSensor();

            // construct ContextObject and pass to dispatcher 
            // Using pass per-event
            var context = new ContextObject(this);

            // Will provide access to raw data from sensors to concrete interceptors
            Dispatcher.OnPostSensorRead(context);
            
            // Will be called right before sending data to clients
            Dispatcher.OnPreSensorDataSent(context);

            // "send" data to clients via observer
            MeasurementsChanged();
        }

        public void Start()
        {
            // just read and display 10 times for demo 
            for (var i = 0; i < 10; i++)
            {
                ReadAndSendSensorData();
                Thread.Sleep(500);
            }
        }
    }
}