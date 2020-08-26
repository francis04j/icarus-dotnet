using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PodcastWebApi.Application.Common.Interfaces;

namespace PodcastWebApi.Application.System.Command.SeedSampleData
{
    public class SeedSampleDataCommand : IRequest
    {
    }

    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly IAppDbContext _context;

        public SeedSampleDataCommandHandler(IAppDbContext context)
        {
            _context = context;

        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}