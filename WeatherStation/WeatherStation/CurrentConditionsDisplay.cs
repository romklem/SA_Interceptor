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
            // Decrypt data from framework prior to display - encrypted through concrete interceptor
            _temp = EncryptionService.Decrypt(temp);
            _humid = EncryptionService.Decrypt(humidity); ; 
            _pressr = EncryptionService.Decrypt(pressure); ;

            Display();
        }

        private void Display()
        {
            Console.WriteLine($"Temperature: {_temp} °F\nHumidity: {Math.Round(_humid * 100, 4)}%\nPressure: {_pressr} hPa\n");
        }
    }
}
