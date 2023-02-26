using WeatherDataLib;

namespace WeatherStation
{
    class ConcreteInterceptor : IInterceptor
    {
        public void OnPostSensorRead(IContextObject context)
        {
            // convert С to А
            var fahrenheit = TempConverterService.ConvertCelsiusToFahrenheit(context.Temperature);
            // Modify framework's state via context
            context.Temperature = fahrenheit;
        }

        public void OnPreSensorDataSent(IContextObject context)
        {
            // simulate encryption of data right before sending to client
            var encrTemp = EncryptionService.Encrypt(context.Temperature);
            var encrHumid = EncryptionService.Encrypt(context.Humidity);
            var encrPressure = EncryptionService.Encrypt(context.Pressure);

            context.Temperature = encrTemp;
            context.Humidity = encrHumid;
            context.Pressure = encrPressure;
        }
    }
}
