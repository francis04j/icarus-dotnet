using System;
using MediatR;

namespace PodcastWebApi.Application.WeatherForecast.Commands.Create
{
    public class CreateWeatherForecastCommand : IRequest<Guid>
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}