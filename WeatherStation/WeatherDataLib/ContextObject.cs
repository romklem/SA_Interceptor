namespace WeatherDataLib
{
    internal class ContextObject : IContextObject
    {
        // Framework handle
        private WeatherData _data;

        public ContextObject(WeatherData data)
        {
            _data = data;
        }

        // breaks encapsulation entirely, but it's just a demo..
        public double Temperature 
        {
            get { return _data._temp; }
            set { _data._temp = value; }
        }

        public double Pressure
        {
            get { return _data._pressure; }
            set { _data._pressure = value; }
        }

        public double Humidity
        {
            get { return _data._humidity; }
            set { _data._humidity = value; }
        }
    }
}
