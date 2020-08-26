using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using PodcastWebApi.Application.Common.Interfaces;

namespace PodcastWebApi.Application.WeatherForecast.Commands.Create
{
    public class CreateWeatherForecastCommandHandler : IRequestHandler<CreateWeatherForecastCommand, Guid>
    {
        private readonly IAppDbContext _context;

        public CreateWeatherForecastCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var entity = new WeatherForecastt
            {
                TemperatureC = request.TemperatureC,
                Date = request.Date,
                Summary = request.Summary
            };

            _context.WeatherForecasts.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.WeatherForecasttId;
        }
    }
}