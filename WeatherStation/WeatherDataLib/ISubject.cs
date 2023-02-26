namespace WeatherDataLib
{
    internal interface IClientSubject
    {
        void RegisterClientObserver(IClientObserver o);
        void RemoveClientObserver(IClientObserver o);
        void NotifyObservers();
    }
}
