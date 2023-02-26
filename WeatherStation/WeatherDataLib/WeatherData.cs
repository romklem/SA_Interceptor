namespace WeatherDataLib
{
    public class WeatherData
    {
        private List<IClientObserver> _clientObservers = new List<IClientObserver>();

        // note internal access mods so they are accessible in ContextObject
        internal double _temp;
        internal double _humidity;
        internal double _pressure;

        private Random _rand = new Random();

        public WeatherData(){ }

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

        private void ReadAndSendSensorData()
        {
            // "read" new data from sensors
            var newTemp = ReadTempSensor();
            var newHumid = ReadHumidSensor();
            var newPress = ReadPressureSensor();

            // call PostSensorRead() 

            // set local values
            _temp = newTemp;
            _humidity = newHumid;
            _pressure = newPress;

            // call PreMeasurementsSent()

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

        // emulate sensors by fluctuatating some fixed value
        private double ReadPressureSensor()
        {
            //hPa
            return 900 + (_rand.Next() % 2 == 0 ? 10 : -10);
        }

        private double ReadHumidSensor()
        {
            // %
            return 0.3 + (_rand.Next() % 2 == 0 ? 0.01 : -0.01);
        }

        private double ReadTempSensor()
        {
            // degree C
            return 20 + (_rand.Next() % 2 == 0 ? 0.1 : -0.1);
        }
    }
}