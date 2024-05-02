using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibTests
{
    [TestClass]
    public class JsonTests
    {
        [TestMethod]
        public void MyTestMethod()
        {
            WeatherForecastWithEnum weatherForecastWithEnum = new WeatherForecastWithEnum()
            {
                Date = DateTime.Now,
                TemperatureCelsius = 30,
                Summary = Summary.Warm,
            };
            Console.WriteLine(JsonSerializer.Serialize(weatherForecastWithEnum));
            Console.WriteLine(JsonSerializer.Serialize(weatherForecastWithEnum, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy =  JsonNamingPolicy.SnakeCaseLower,
                Converters =
                    {
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                    }
            }));
        }
    }

    internal class WeatherForecastWithEnum
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public Summary? Summary { get; set; }
    }

    internal enum Summary
    {
        Cold, Cool, Warm, Hot
    }
}
