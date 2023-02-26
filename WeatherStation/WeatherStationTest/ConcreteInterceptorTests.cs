using NUnit.Framework;
using WeatherDataLib;
using WeatherStation;

namespace WeatherStationTest
{
    public class ConcreteInterceptorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConcreteInterceptorTest_TestEncryptionWithPredefinedValue_AreEqual()
        {
            // Arrange
            // set up mocks
            var mockData = 10;
            var mockSensor = new SensorMock(mockData);
            var mockClient = new ClientObserverMock();

            // set up code under test - more like integration test
            var weatherData = new WeatherData(mockSensor);
            weatherData.RegisterObserver(mockClient);
            var interceptor = new ConcreteInterceptor();
            weatherData.Dispatcher.RegisterInterceptor(interceptor);

            // Act
            weatherData.Start();

            // Assert
            var encryptedData = EncryptionService.Encrypt(mockData);

            Assert.AreEqual(encryptedData, mockClient.Humidity);
        }
    }
}