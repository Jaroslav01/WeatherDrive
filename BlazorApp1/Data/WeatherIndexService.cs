using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp1.Api;

namespace BlazorApp1.Data
{
    public class WeatherIndexService
    {
        private static readonly string[] daysOfTheWeek = new[]
        {
            "Now", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" , "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" , "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        };

        public Task<WeatherIndex[]> GetIndexAsync(DateTime startDate, string City)
        {
            Weather wather = new Weather();
            MyAPI myAPI = new MyAPI();
            Weather_Hourly weather_Hourly = new Weather_Hourly();
            Place place = new Place();

            var response_ip = myAPI.get_myipdata();

            if (City == "")
            {
                City = myAPI.city(response_ip);
            }

            var response_weather = wather.get_weather(City);
            var response_weather_hourly = weather_Hourly.GetWeatherCoordinatesHourly(wather.lat(response_weather), wather.lon(response_weather));

            int length = weather_Hourly.DaylyHim(response_weather_hourly).Count;

            
            string[] day = new string[length + 1];
            string[] icon = new string[length + 1];
            string[] city = new string[length + 1];
            string[] temp = new string[length + 1];
            string[] him = new string[length + 1];
            string[] pressure = new string[length + 1];
            string[] description = new string[length + 1];
            string[] ip = new string[length + 1];

            ip[0] = myAPI.ip(response_ip);
            city[0] = wather.name(response_weather);
            icon[0] = $"http://openweathermap.org/img/wn/{wather.icon(response_weather)}@2x.png";
            description[0] = wather.icon(response_weather);
            temp[0] = wather.Temp(response_weather);
            him[0] = wather.humidity(response_weather);
            pressure[0] = wather.pressure(response_weather);
            day[0] = "sdf";

            for (int i = 0; i < length; i++)
            {
                ip[i + 1] = myAPI.ip(response_ip);
                city[i + 1] = wather.name(response_weather);
                icon[i + 1] = $"http://openweathermap.org/img/wn/{weather_Hourly.DaylyIcon(response_weather_hourly)[i]}@2x.png";
                description[i + 1] = weather_Hourly.DaylyClouds(response_weather_hourly)[i];
                temp[i + 1] = weather_Hourly.DaylyTemp(response_weather_hourly)[i];
                him[i + 1] = weather_Hourly.DaylyHim(response_weather_hourly)[i];
                pressure[i + 1] = weather_Hourly.DaylyPressure(response_weather_hourly)[i];
                day[i + 1] = startDate.AddDays(i).ToString("");
            }

            return Task.FromResult(Enumerable.Range(0, length).Select(i => new WeatherIndex
            {
                City = city[i],
                Icon = icon[i],
                Temp = temp[i],
                Him = him[i],
                Pressure = pressure[i],
                Description = description[i],
                Day = daysOfTheWeek[i],
            }).ToArray());
        }
    }
}
