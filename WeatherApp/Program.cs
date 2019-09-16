using System;
using System.IO;
using Newtonsoft.Json;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("Welcome To The RDU Weather App!\n\nThis Application uses 30 years worth of data to predict the weather at the Raleigh-Durham International Airport.\n");

                // Request user input for month and assigns the input to a variable.
                Console.Write("First, please enter the month you would like to check the weather for:\n(Format: January, February, etc.) - (Leave blank for this month): ");
                string month = Console.ReadLine();

                // Request user input for day and assigns the input to a variable.
                Console.Write("\nNow, please enter the day of the month you would like to check the weather for:\n(Format: 1, 2, etc.) - (Leave blank for today's date): ");
                string day = Console.ReadLine();

                // Calls the WeatherForecast function and assigns it's value to output variable.
                string output = WeatherForecast.Forecast(month, day);

                // Prints the output to the console.
                Console.WriteLine(output);
                Console.WriteLine("Thank you for using the RDU Weather App! Please re-run the application to check another date!");
            }
        }
    }
		public static class WeatherForecast
		{
			// Forecast function is defined with paramters.
			public static string Forecast(string month, string day)
			{
				// Program reads the json file using StreamReader.
				using (StreamReader r = new StreamReader(@"weatherdata.json"))
				{
					string json = r.ReadToEnd();
					// Json is deserialized into an object so that the data can be easily parsed.
					var weather = JsonConvert.DeserializeObject<dynamic>(json);

					// If input is blank, variable is assigned to current month using DateTime.
					if (month == "")
					{
						month = DateTime.Now.ToString("MMMM");
					}

					//If input is blank, variable is assigned to current day using DateTime.
					if (day == "")
					{
						day = DateTime.Now.ToString("dd");
					}
					// Loop through each record to find matching Month and Day.
					foreach (var record in weather)
					{
						/* Convert both record and input to uppercase to avoid casing issue.
                        If match is found for both Month and Day, print result statement to the user. */
						if (record.Month.ToString().ToUpper() == month.ToUpper() && record.DayOfMonth.ToString() == day)
						{
							return $"\nOn average, the high for {record.Month} {record.DayOfMonth} is {record.NormalMaxTemp}°F, the low is {record.NormalMinTemp}°F and there is {record.NormalPrecipitation} inches of rain.\n";
						}
					}
				}
				// If no match is found, output states this and recommends trying different format.
				return $"\nThere is no record for {month} {day}. Please ensure your request was formated correctly.\n(Month Format: August, January, etc.) - (Day Format: 4, 30, etc.)\n";
			}
		}
}

