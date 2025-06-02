using MassTransit;
using rabbitmq_dotnet_sample.Api.Bus;
using rabbitmq_dotnet_sample.Api.Bus.Consumers;

namespace rabbitmq_dotnet_sample.Api.Extensions;

public static class AppExtensions
{
    public static void AddRabbitMqService(this IServiceCollection services, IConfiguration configuration)
    {

        // Register the bus publish service
        services.AddTransient<IProjectPublishBus, ProjectPublishBus>();
        
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(configuration.GetConnectionString("RabbitMQ") ?? string.Empty), host =>
                {
                    host.Username(configuration.GetValue("Secrets:RabbitMQUserName", string.Empty)!);
                    host.Password(configuration.GetValue("Secrets:RabbitMQPassword", string.Empty)!);
                });
                
                cfg.ConfigureEndpoints(context);
            });
            
            busConfigurator.AddConsumer<RequestedReportEventConsumer>();
        });
    }
}