using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Common;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;
using PodcastWebApi.Application.Common.Interfaces;

namespace Persistence
{
    public class RecoupDbContext : DbContext, IAppDbContext
    {
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public RecoupDbContext(DbContextOptions<RecoupDbContext> options) : base(options)
        {
        }

        public RecoupDbContext(DbContextOptions<RecoupDbContext> options,
            ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WeatherForecasttConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecoupDbContext).Assembly);
        }

        public DbSet<Episode> Episodes { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public void AddEpisode(Episode episode)
        {
            Episodes.Add(episode);
        }

        public DbSet<WeatherForecastt> WeatherForecasts { get; set; }
    }
}