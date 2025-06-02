namespace rabbitmq_dotnet_sample.Api.Bus;

public interface IProjectPublishBus
{
    Task PublishAsync<T>(T message, CancellationToken ct = default) where T : class;
}