namespace WeatherDataLib
{
    public class Dispatcher : IInterceptor  // use same interface for callbacks
    {
        private List<IInterceptor> _interceptors = new List<IInterceptor>();

        public void RegisterInterceptor(IInterceptor interceptor)
        {
            _interceptors.Add(interceptor);
        }

        public void UnregisterInterceptor(IInterceptor interceptor)
        {
            _interceptors.Remove(interceptor);
        }

        public void OnPostSensorRead(IContextObject context)
        {
            foreach(var interceptor in _interceptors)
            {
                interceptor.OnPostSensorRead(context);
            }
        }

        public void OnPreSensorDataSent(IContextObject context)
        {
            foreach(var interceptor in _interceptors)
            {
                interceptor.OnPreSensorDataSent(context);
            }
        }
    }
}
