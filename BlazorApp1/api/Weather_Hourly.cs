using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using BlazorApp1.Pages;
using BlazorApp1.Data;
namespace BlazorApp1.Api
{
    class Weather_Hourly
    {
        public string get_weather_coordinates_hourly(string lat, string lon)
        {
            string api = "c99ae9a8c5fb62b510a1558da2444576";
            string lang = "ru";
            using var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(
                $"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&appid={api}&lang={lang}")
                .GetAwaiter().GetResult();
            return response;
        }
        public List<string> temp(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["hourly"];
            int length = jArray.Count;
            var array1 = new List<string>();
            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["hourly"][i]["temp"]}");
            }
            return array1;
        }
        public List<string> humidity(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["hourly"];
            int length = jArray.Count;
            var array1 = new List<string>();
            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["hourly"][i]["humidity"]}");
            }
            return array1;
        }
        public List<string> pressure(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["hourly"];
            int length = jArray.Count;
            var array1 = new List<string>();
            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["hourly"][i]["pressure"]}");
            }
            return array1;
        }
        public List<string> clouds(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["hourly"];
            int length = jArray.Count;
            var array1 = new List<string>();
            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["hourly"][i]["weather"][0]["description"]}");
            }
            return array1;
        }
    }
}
