using WeatherDataLib;

namespace WeatherStationTest
{
    internal class ClientObserverMock : IClientObserver
    {
        public double Humidity { get; set; }
        public void UpdateReadings(double temp, double humidity, double pressure)
        {
            Humidity = humidity;
        }
    }
}
