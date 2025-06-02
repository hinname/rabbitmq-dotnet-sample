using rabbitmq_dotnet_sample.Api.Reports;

namespace rabbitmq_dotnet_sample.Api.Extensions;

public static class StatusExtension
{
    public static string StatusToString(this Status status)
    {
        return status switch
        {
            Status.Pending => "Pending",
            Status.InProgress => "In Progress",
            Status.Completed => "Completed",
            Status.Failed => "Failed",
            _ => string.Empty,
        };
    }
}