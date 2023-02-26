namespace WeatherDataLib
{
    public interface IClientObserver
    {
        void UpdateReadings(double temp, double humidity, double pressure);
    }
}
