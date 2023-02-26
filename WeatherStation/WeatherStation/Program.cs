using System;
using System.ComponentModel;
using WeatherDataLib;

namespace WeatherStation
{
    internal class Program
    {
        private static BackgroundWorker _worker = new BackgroundWorker();

        static void Main(string[] args)
        {
            var weatherData = new WeatherData();
            var display = new CurrentConditionsDisplay();

            weatherData.RegisterObserver(display);
            weatherData.Start();

        }
    }
}