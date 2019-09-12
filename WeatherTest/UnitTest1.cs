using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using WeatherApp;
using System.Linq;

namespace WeatherTest
{
    [TestClass]
    public class ForecastTest
    {
        [TestMethod]
        public void WeatherForecastGiven()
        {
            // Arrange

            // Assigned test variables for unit test.
            string month = "January";
            string day = "2";

            // Variable for the expected result with test variables.
            string expected = $"\nOn average, the high for {month} {day} is 50.5°F, the low is 30.8°F and there is 0.1 inches of rain.\n";

            // Act

            // Variable storing the actual result using test variables.
            string actual = $"{WeatherForecast.Forecast(month, day)}";

            // Assert

            // Comparison between expected and actual results to determine if they are equal or not.
            Assert.AreEqual(expected, actual);
        }
    }
}
