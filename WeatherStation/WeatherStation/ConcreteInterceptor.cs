using WeatherDataLib;

namespace WeatherStation
{
    class ConcreteInterceptor : IInterceptor
    {
        public void OnPostSensorRead(IContextObject context)
        {
            Console.WriteLine("_____Concrete OnPostSensorRead called");
        }

        public void OnPreSensorDataSent(IContextObject context)
        {
            Console.WriteLine("_____Concrete OnPreSensorDataSent called");
        }
    }
}
