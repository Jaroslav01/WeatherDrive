using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using BlazorApp1.Pages;
using BlazorApp1.Data;
namespace BlazorApp1.Api
{
    class Direction
    {
        string api = "AIzaSyB41WUy4DzQbM6LXIYawZwzApM8QoXd5g8";
        public string get_direction_coordinates(string start_lat, string start_lng, string end_lat, string end_lng)
        {
            using var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(
                $"https://maps.googleapis.com/maps/api/directions/json?origin={start_lat},{start_lng}&destination={end_lat},{end_lng}&key={api}")
                .GetAwaiter().GetResult();
            return response;
        }
        public string get_direction_namecity(string start_city, string end_city)
        {
            using var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(
                $"https://maps.googleapis.com/maps/api/directions/json?origin={start_city}&destination={end_city}&key={api}")
                .GetAwaiter().GetResult();
            return response;
        }
        public List<string> lat(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["routes"][0]["legs"][0]["steps"];
            int length = jArray.Count;
            var array1 = new List<string>();

            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["routes"][0]["legs"][0]["steps"][i]["start_location"]["lat"]}");
            }
            return array1;
        }
        public List<string> lng(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["routes"][0]["legs"][0]["steps"];
            int length = jArray.Count;
            var array1 = new List<string>();

            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["routes"][0]["legs"][0]["steps"][i]["start_location"]["lng"]}");

            }
            return array1;
        }
        public List<double> time_value(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["routes"][0]["legs"][0]["steps"];
            int length = jArray.Count;
            var array1 = new List<double>();
            array1.Add(0);
            for (int i = 1; i < length; i++)
            {
                int lis = Convert.ToInt32($"{tree["routes"][0]["legs"][0]["steps"][i]["duration"]["value"]}");
                array1.Add(array1[i - 1] + lis);

            }
            return array1;
        }
    }
}
