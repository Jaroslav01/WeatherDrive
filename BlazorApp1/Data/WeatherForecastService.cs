using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlazorApp1.Data
{
    public class WeatherForecastService
    {
        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate, string firstCity, string secondCity)
        {
            Api.Weather weather = new Api.Weather();
            Api.Direction direction = new Api.Direction();
            Api.Weather_Hourly weather_Hourly = new Api.Weather_Hourly();
            
            var response_direction = direction.get_direction_namecity(firstCity, secondCity);

            List<string> city = new List<string>();
            List<DateTime> date = new List<DateTime>();
            List<string> HourlyTemp = new List<string>();
            List<string> himidiatly = new List<string>();
            List<string> pressure = new List<string>();
            List<string> summary = new List<string>();

            for (int i = 0; i < direction.lat(response_direction).Count; i++)
            {
                var response_weather_hourly = weather_Hourly.GetWeatherCoordinatesHourly(direction.lat(response_direction)[i], direction.lng(response_direction)[i]);
                var response_weather_coords = weather.get_weather_coordinates(direction.lat(response_direction)[i], direction.lng(response_direction)[i]);

                int time =  Convert.ToInt32(Math.Round(direction.time_value(response_direction)[i] / 60 / 60, 0));

                himidiatly.Add(weather_Hourly.humidity(response_weather_hourly)[time]);
                HourlyTemp.Add(weather_Hourly.Temp(response_weather_hourly)[time]);
                pressure.Add(weather_Hourly.pressure(response_weather_hourly)[time]);
                city.Add(weather.name(response_weather_coords));
                date.Add(startDate.AddDays(i).AddHours(i));
            }

            return Task.FromResult(Enumerable.Range(0, direction.lat(response_direction).Count).Select(i => new WeatherForecast
            {
                City = city[i],
                Date = date[i],
                Pressure = pressure[i],
                TemperatureC = HourlyTemp[i],
                Himidiatly = himidiatly[i],
            }).ToArray());
        }
    }
}
