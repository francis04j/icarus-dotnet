using System;
using AutoMapper;
using Domain.Entities;
using PodcastWebApi.Application.Common.Mappings;

namespace PodcastWebApi.Application.WeatherForecast.Queries.GetWeatherForecast
{
    public class WeatherForecastVm : IMapFrom<WeatherForecastt>
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<WeatherForecastt, WeatherForecastVm>();
        }
    }
}