using System;
using AutoMapper;
using Common;
using Persistence;
using PodcastWebApi.Application.Common.Mappings;
using Xunit;

namespace Application.UnitTests
{
    public class QueryTestFixture : IDisposable
    {
        public RecoupDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture(IDateTime dateTime)
        {
            Context = RecoupDbContextFactory.Create(dateTime);

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            RecoupDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
