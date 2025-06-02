using MassTransit;

namespace rabbitmq_dotnet_sample.Api.Bus;

public class ProjectPublishBus: IProjectPublishBus
{
    private readonly IPublishEndpoint _busPublishEndpoint;
    
    public ProjectPublishBus(IPublishEndpoint busPublishEndpoint)
    {
        _busPublishEndpoint = busPublishEndpoint;
    }
    
    public Task PublishAsync<T>(T message, CancellationToken ct = default) where T : class
    {
        return _busPublishEndpoint.Publish(message, ct);
    }
}