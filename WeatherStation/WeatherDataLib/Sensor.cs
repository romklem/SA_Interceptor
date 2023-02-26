

namespace WeatherDataLib
{
    internal class Sensor : ISensor
    {
        private Random _rand = new Random();

        // emulate sensors by fluctuatating some fixed value
        public double ReadPressureSensor()
        {
            //hPa
            return 900 + (_rand.Next() % 2 == 0 ? 10 : -10);
        }

        public double ReadHumidSensor()
        {
            // %
            return 0.3 + (_rand.Next() % 2 == 0 ? 0.01 : -0.01);
        }

        public double ReadTempSensor()
        {
            // degree C
            return 20 + (_rand.Next() % 2 == 0 ? 0.1 : -0.1);
        }
    }
}
