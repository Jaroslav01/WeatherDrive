using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System;

namespace BlazorApp1.Api
{
    class Weather_Hourly
    {
        public string GetWeatherCoordinatesHourly(string lat, string lon)
        {
            string api = "c99ae9a8c5fb62b510a1558da2444576";
            string lang = "en";
            using var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(
                $"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&appid={api}&lang={lang}")
                .GetAwaiter().GetResult();
            return response;
        }
        public List<string> DaylyTemp(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["daily"];
            int length = jArray.Count;
            var array1 = new List<string>();
            
            for (int i = 0; i < length; i++)
            {
                string a = $"{Math.Round(tree["daily"][i]["temp"]["day"].Value<double>() - 273, 1)}°C";
                array1.Add(a);
            }
            return array1;
        }
        public List<string> DaylyHim(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["daily"];
            int length = jArray.Count;
            var array1 = new List<string>();
            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["daily"][i]["humidity"]}%");
            }
            return array1;
        }
        public List<string> DaylyPressure(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["daily"];
            int length = jArray.Count;
            var array1 = new List<string>();
            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["daily"][i]["pressure"]}mh");
            }
            return array1;
        }
        public List<string> DaylyClouds(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["daily"];
            int length = jArray.Count;
            var array1 = new List<string>();
            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["daily"][i]["weather"][0]["main"]}");
            }
            return array1;
        }
        public List<string> DaylyCloudsDescription(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["daily"];
            int length = jArray.Count;
            var array1 = new List<string>();
            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["daily"][i]["weather"][0]["description"]}");
            }
            return array1;
        }
        public List<string> DaylyIcon(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["daily"];
            int length = jArray.Count;
            var array1 = new List<string>();
            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["daily"][i]["weather"][0]["icon"]}");
            }
            return array1;
        }
        public List<string> Temp(string response)
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
