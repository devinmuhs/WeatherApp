using System;
using System.IO;
using Newtonsoft.Json;

namespace WeatherApp
{
    class Program
    {

        static void Main(string[] args)
        {
            // Program reads the json file using StreamReader.
            using (StreamReader r = new StreamReader(@"weather-data.json"))
            {
                string json = r.ReadToEnd();
                // Json is deserialized into an object so that the data can be easily parsed.
                var weather = JsonConvert.DeserializeObject<dynamic>(json);
                Console.WriteLine("Welcome To The RDU Weather App!\n\nThis Application uses 30 years worth of data to predict the weather at the Raleigh-Durham International Airport.\n");

                // Request user input for month and assigns the input to a variable.
                Console.Write("First, please enter the month you would like to check the weather for:\n(Leave blank for this month) - (Format: January, February, etc.): ");
                string month = Console.ReadLine();

                // If input is blank, variable is assigned to current month using DateTime. 
                if (month == "")
                {
                    month = DateTime.Now.ToString("MMMM");
                }

                // Request user input for day and assigns the input to a variable..
                Console.Write("\nNow, please enter the day of the month you would like to check the weather for:\n(Leave blank for todays' date) - (Format: 1, 2, etc.): ");
                string day = Console.ReadLine();

                //If input is blank, variable is assigned to current day using DateTime.
                if (day == "")
                {
                    day = DateTime.Now.ToString("dd");
                }

                // Loop through each record to find matching Month and Day.
                foreach (var record in weather)
                {
                    // Convert both record and input to uppercase to avoid casing issue
                    // If match is found for both Month and Day, print result statement to the user.
                    if (record.month.ToString().ToUpper() == month.ToUpper() && record.dayOfMonth.ToString().ToUpper() == day)
                    {
                        Console.WriteLine($"\nOn average, the high for {record.month} {record.dayOfMonth} is {record.normalMaxTemp}°F, the low is {record.normalMinTemp}°F and there is {record.normalPrecipitation} inches of rain.\n");
                    }
                    //else
                    //{
                    //    Console.WriteLine($"There is no record for {month} {day}. Please ensure your request was formated correctly. Example: June 1, January 30, etc.");
                    //}

                    //if (record.month.Contains(month) == false && record.dayOfMonth.Contains(day) == false)
                    //{
                    //    Console.WriteLine($"There is no record for {month} {day}. Please ensure your request was formated correctly. Example: June 1, January 30, etc.");
                    //}
                }
                Console.WriteLine("Thank you for using the RDU Weather App, please re-run the application to check another date!");
            }

        }
    }
}
