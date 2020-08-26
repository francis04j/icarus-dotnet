using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using PodcastWebApi.Application.Common.Interfaces;

namespace PodcastWebApi.Application.Episodes.Commands
{
    public class CreateEpisodeCommandHandler : IRequestHandler<CreateEpisodeCommand>
    {
        private readonly IAppDbContext _context;
        private readonly IMediator _mediator;

        public CreateEpisodeCommandHandler(IAppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateEpisodeCommand command, CancellationToken cancellationToken)
        {
            var entity = new Episode
            {
                Content = command.Content,
                Title = command.Title
            };
            _context.AddEpisode(entity);
            // _context.Episodes.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new EpisodeCreated { EpisodeId = entity.Title }, cancellationToken);


            return Unit.Value;
        }
    }
}