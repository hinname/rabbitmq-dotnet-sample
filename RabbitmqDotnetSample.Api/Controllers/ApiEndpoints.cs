namespace rabbitmq_dotnet_sample.Api.Controllers;

public static class ApiEndpoints
{
    public static void AddApiEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");
    }
}