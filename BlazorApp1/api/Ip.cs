using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using BlazorApp1.Pages;
using BlazorApp1.Data;
using Microsoft.AspNetCore.Http;

namespace BlazorApp1.Api
{
    class MyAPI
    {
        public string get_myipdata()
        {
            using var httpClient = new HttpClient();
            System.Net.Http.HttpClient httpClient1 = new HttpClient();
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            
          var response = httpClient.GetStringAsync(
               $"https://api.ipdata.co/?api-key=test")
                .GetAwaiter().GetResult();
            //var response = httpClient.GetStringAsync(
              //   $"https://api.ipgeolocation.io/ipgeo?apiKey=31f71006a46c4290a25d6b33f9f73375")
                // .GetAwaiter().GetResult();
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
