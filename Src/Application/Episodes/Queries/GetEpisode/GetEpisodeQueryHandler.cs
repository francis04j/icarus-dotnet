using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using PodcastWebApi.Application.Common.Interfaces;

namespace PodcastWebApi.Application.WeatherForecast.Queries.GetEpisode
{
    public class GetEpisodeQueryHandler: IRequestHandler<GetEpisodeQuery, IEnumerable<GetEpisodeVm>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetEpisodeQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetEpisodeVm>> Handle(GetEpisodeQuery request, CancellationToken cancellationToken)
        {
            request.Title = "hello";
            // var titleFilter = $"episode => episode.Title.Equals(\"hello\")";
            string vee = $"episode => episode.Title.Equals(\"{request.Title}\")";
            var titleFilter = vee;
            var options = ScriptOptions.Default.AddReferences(typeof(Episode).Assembly);

            Func<Episode, bool> titleFilterExpression = 
                await CSharpScript.EvaluateAsync<Func<Episode, bool>>(titleFilter, options);

            var discountedAlbums = _context.Episodes.Where(IsSelling(request));

            var vm = await _context.Episodes.Where(x => x.Title == request.Title) // Date.Equals(request.Date))
                    .ProjectTo<GetEpisodeVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);


            return vm;
        }

        public static Expression<Func<Episode, bool>> IsSelling(GetEpisodeQuery request)
        {
            return prod =>
              prod.Title.Equals(request.Title) ||
               prod.Content.Equals(request.Content);
        }
    }
}