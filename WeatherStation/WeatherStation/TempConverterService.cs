namespace WeatherStation
{
    public class TempConverterService
    {
        public static double ConvertCelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }
    }
}
