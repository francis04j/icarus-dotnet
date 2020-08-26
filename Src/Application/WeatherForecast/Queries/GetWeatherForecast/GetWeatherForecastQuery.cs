using System;
using MediatR;

namespace PodcastWebApi.Application.WeatherForecast.Queries.GetWeatherForecast
{
    public class GetWeatherForecastQuery : IRequest<WeatherForecastVm>
    {
        public DateTime Date { get; set; }
    }
}