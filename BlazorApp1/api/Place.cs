using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace BlazorApp1.Api
{
    class Place
    {
        readonly string api = "AIzaSyB41WUy4DzQbM6LXIYawZwzApM8QoXd5g8";
        public string get_place(string search, string locatin)
        {
            using var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(
                $"https://maps.googleapis.com/maps/api/place/textsearch/json?query={search}+in+{locatin}&key={api}")
                .GetAwaiter().GetResult();
            return response;
        }
        public List<string> address(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["results"];
            int length = jArray.Count;
            var array1 = new List<string>();

            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["results"][i]["formatted_address"]}");

            }
            return array1;
        }
        public List<string> name(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["results"];
            int length = jArray.Count;
            var array1 = new List<string>();

            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["results"][i]["name"]}");

            }
            return array1;
        }
        public List<string> lat(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["results"];
            int length = jArray.Count;
            var array1 = new List<string>();

            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["results"][i]["geometry"]["location"]["lat"]}");

            }
            return array1;
        }
        public List<string> lng(string response)
        {
            var tree = JObject.Parse(response);
            JArray jArray = (JArray)tree["results"];
            int length = jArray.Count;
            var array1 = new List<string>();

            for (int i = 0; i < length; i++)
            {
                array1.Add($"{tree["results"][i]["geometry"]["location"]["lng"]}");

            }
            return array1;
        }
    }
}
