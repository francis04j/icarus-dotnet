using Xunit;
using MediatR;
using Moq;
using System.Threading;
using Domain.Entities;
using PodcastWebApi.Application.Common.Interfaces;
using PodcastWebApi.Application.Episodes.Commands;

public class CreateEpisodeCommandHandlerTests  {
    
    [Fact]
    public void Should_Insert_Item_to_DB_Given_Valid_Request()
    {
    //Given
        var mediatorMock = new Mock<IMediator>();
        var dbContextMock = new Mock<IAppDbContext>();
        
        var sut = new CreateEpisodeCommandHandler(dbContextMock.Object, mediatorMock.Object);
        var command = new CreateEpisodeCommand { Id = "1", Title = "Title", Content = "Content"};
        dbContextMock.Setup(x => x.AddEpisode(It.IsAny<Episode>()));
        var cancellationToken = CancellationToken.None;
    //When
        var result = sut.Handle(command, cancellationToken);
    //Then
        dbContextMock.Verify(x => x.SaveChangesAsync(cancellationToken), Times.Once);
        mediatorMock.Verify(m => m.Publish(It.Is<EpisodeCreated>(cc => cc.EpisodeId == command.Title), cancellationToken), Times.Once);
    }

    [Fact]
    public void Handle_GivenValidRequest_ShouldRaiseEpisodeCreatedNotification()
    {
        //Given
        var mediatorMock = new Mock<IMediator>();
        var dbContextMock = new Mock<IAppDbContext>();

        var sut = new CreateEpisodeCommandHandler(dbContextMock.Object, mediatorMock.Object);
        var command = new CreateEpisodeCommand { Id = "1", Title = "Title", Content = "Content" };
        dbContextMock.Setup(x => x.AddEpisode(It.IsAny<Episode>()));
        var cancellationToken = CancellationToken.None;
        //When
        var result = sut.Handle(command, cancellationToken);
        //Then
        mediatorMock.Verify(m => m.Publish(It.Is<EpisodeCreated>(cc => cc.EpisodeId == command.Title), cancellationToken), Times.Once);
    }
}
