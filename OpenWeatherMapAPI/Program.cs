using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OperWeatherMapAPI;

class Program
{
    static void Main(string[] args)
    {
        var client = new HttpClient();
        Console.WriteLine("Please enter your API key.");
        var api_Key = Console.ReadLine();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter the city you would like to look up.");
            var cityName = Console.ReadLine().ToLower();
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={api_Key}";

            var response = client.GetStringAsync(weatherURL).Result;
            var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
            Console.WriteLine($"{formattedResponse}");
            Console.WriteLine();
            Console.WriteLine("Would you like to search for another city?");
            var userInput = Console.ReadLine();
            Console.WriteLine();
            if (userInput == "no")
            {
                break;
            }

        }
    }
}

