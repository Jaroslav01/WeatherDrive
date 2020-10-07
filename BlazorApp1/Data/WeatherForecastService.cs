using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlazorApp1.Api;

namespace BlazorApp1.Data
{
    public class WeatherForecastService
    {
        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate, string firstCity, string secondCity)
        {
            Weather weather = new Weather();
            Direction direction = new Direction();
            Weather_Hourly weather_Hourly = new Weather_Hourly();

            var response_direction = direction.get_direction_namecity(firstCity, secondCity);

            List<string> city = new List<string>();
            List<string> date = new List<string>();
            List<string> hourlyTemp = new List<string>();
            List<string> himidiatly = new List<string>();
            List<string> pressure = new List<string>();
            List<string> summary = new List<string>();
            List<string> icon = new List<string>();

            string previousCity = firstCity;

            for (int i = 0; i < direction.lat(response_direction).Count; i++)
            {
                var response_weather_hourly = weather_Hourly.GetWeatherCoordinatesHourly(direction.lat(response_direction)[i], direction.lng(response_direction)[i]);
                var response_weather_coords = weather.get_weather_coordinates(direction.lat(response_direction)[i], direction.lng(response_direction)[i]);

                int time =  Convert.ToInt32(Math.Round(direction.time_value(response_direction)[i] / 60 / 60, 0));

                startDate.AddSeconds(direction.time_value(response_direction)[i]);

                if ((previousCity == weather.name(response_weather_coords)) && (i > 0)) {
                    previousCity = weather.name(response_weather_coords);
                    continue;
                }
                previousCity = weather.name(response_weather_coords);

                himidiatly.Add(weather_Hourly.humidity(response_weather_hourly)[time]);
                hourlyTemp.Add(weather_Hourly.Temp(response_weather_hourly)[time]);
                pressure.Add(weather_Hourly.pressure(response_weather_hourly)[time]);
                city.Add(weather.name(response_weather_coords));
                date.Add(startDate.AddHours(time).ToString("dd | HH:mm"));
                icon.Add($"http://openweathermap.org/img/wn/{weather.icon(response_weather_coords)}@2x.png");
            }

            return Task.FromResult(Enumerable.Range(0, city.Count).Select(i => new WeatherForecast
            {
                City = city[i],
                Date = Convert.ToString( date[i]),
                Pressure = pressure[i],
                TemperatureC = hourlyTemp[i],
                Himidiatly = himidiatly[i],
                Icon = icon[i],
            }).ToArray());
        }
    }
}
