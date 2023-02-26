namespace WeatherDataLib
{
    public interface IContextObject
    {
        double Temperature { get; set; }
        double Humidity { get; set; }
        double Pressure { get; set; }
    }
}
