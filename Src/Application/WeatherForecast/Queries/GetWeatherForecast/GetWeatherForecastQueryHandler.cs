using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PodcastWebApi.Application.Common.Interfaces;

namespace PodcastWebApi.Application.WeatherForecast.Queries.GetWeatherForecast
{
    public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, WeatherForecastVm>
    {

        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetWeatherForecastQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WeatherForecastVm> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.WeatherForecasts.Where(x => x != null) // Date.Equals(request.Date))
                .ProjectTo<WeatherForecastVm>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);


            return vm;
        }
    }
}
