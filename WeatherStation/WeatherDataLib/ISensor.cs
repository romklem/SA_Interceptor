namespace WeatherDataLib
{
    public interface ISensor
    {
        double ReadPressureSensor();

        double ReadHumidSensor();

        double ReadTempSensor();
    }
}
