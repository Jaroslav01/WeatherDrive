using Newtonsoft.Json.Linq;
using System.Net.Http;
using BlazorApp1.Pages;
using BlazorApp1.Data;
namespace BlazorApp1.Api
{
    class MyAPI
    {
        public string get_myipdata()
        {
            using var httpClient = new HttpClient();
            //var response = httpClient.GetStringAsync(
               //$"https://api.ipdata.co/?api-key=test")
                //.GetAwaiter().GetResult();
            var response = httpClient.GetStringAsync(
                 $"https://api.ipgeolocation.io/ipgeo?apiKey=31f71006a46c4290a25d6b33f9f73375")
                 .GetAwaiter().GetResult();
            return response;
        }
        public string city(string response)
        {
            var tree = JObject.Parse(response);
            return $"{tree["city"]}";
        }
        public string ip(string response)
        {
            var tree = JObject.Parse(response);
            return $"{tree["ip"]}";
        }
    }
}
