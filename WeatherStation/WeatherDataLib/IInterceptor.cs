namespace WeatherDataLib
{
    // normally would call it ReadAndSendSensorDataInterceptor
    public interface IInterceptor
    {
        void OnPostSensorRead(IContextObject context);
        void OnPreSensorDataSent(IContextObject context);
    }
}
