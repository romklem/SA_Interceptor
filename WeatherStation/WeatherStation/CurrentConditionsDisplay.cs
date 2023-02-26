using WeatherDataLib;

namespace WeatherStation
{
    public class CurrentConditionsDisplay : IClientObserver
    {
        private double _temp;
        private double _humid;
        private double _pressr;

        public void UpdateReadings(double temp, double humidity, double pressure)
        {
            _temp = temp;
            _humid = humidity; 
            _pressr = pressure;

            Display();
        }

        private void Display()
        {
            Console.WriteLine($"Temperature: {_temp} C\nHumidity: {_humid}%\nPressure: {_pressr} hPa\n");
        }
    }
}
