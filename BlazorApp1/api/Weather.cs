using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace BlazorApp1.Api
{
    class Weather
    {
        readonly string api = "c99ae9a8c5fb62b510a1558da2444576";
        readonly string lang = "en";
        public string get_weather(string city)
        {
            using var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(
                $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={api}&lang={lang}")
                .GetAwaiter().GetResult();
            return response;
        }
        public string get_weather_coordinates(string lat, string lon)
        {
            using var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(
                $"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={api}&lang={lang}")
                .GetAwaiter().GetResult();
            return response;
        }
        public string Temp(string response)
        {
            var tree = JObject.Parse(response);
            return $"{Math.Round(tree["main"]["temp"].Value<double>() - 273, 1)}";
        }
        public string humidity(string response)
        {
            var tree = JObject.Parse(response);
            return $"{Math.Round(tree["main"]["humidity"].Value<double>(), 1)}%";
        }
        public string pressure(string response)
        {
            var tree = JObject.Parse(response);
            return $"{Math.Round(tree["main"]["pressure"].Value<double>(), 1)}mm";
        }
        public string icon(string response)
        {
            var tree = JObject.Parse(response);
            return $"{tree["weather"][0]["icon"].Value<string>()}";
        }
        public string name(string response)
        {
            var tree = JObject.Parse(response);
            return $"{tree["name"].Value<string>()}";
        }
        public string lon(string response)
        {
            var tree = JObject.Parse(response);
            return $"{tree["coord"]["lon"]}";
        }
        public string lat(string response)
        {
            var tree = JObject.Parse(response);
            return $"{tree["coord"]["lat"]}";
        }
    }
}
