using WeatherDataLib;

namespace WeatherStationTest
{
    internal class SensorMock : ISensor
    {
        double _testData;
        public SensorMock(double testData)
        {
            _testData = testData;
        }

        public double ReadHumidSensor()
        {
            return _testData;
        }

        public double ReadPressureSensor()
        {
            return _testData;
        }

        public double ReadTempSensor()
        {
            return _testData;
        }
    }
}
