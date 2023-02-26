using WeatherDataLib;

namespace WeatherStation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // concrete framework
            var weatherData = new WeatherData();

            // client using data from framework (original observer)
            var displayClient = new CurrentConditionsDisplay();

            // concrete interceptor providing out-of-band encryption and conversion services
            var interceptor = new ConcreteInterceptor();

            // attach interceptor to dispatcher
            // NOTE: For security might want to NOT expose Dispatcher and only allow registering i-ceptors via separate method
            weatherData.Dispatcher.RegisterInterceptor(interceptor);

            // register client with framework (original Observer pattern)
            weatherData.RegisterObserver(displayClient);

            // will provide 10 measurements for demo
            weatherData.Start();
        }
    }
}