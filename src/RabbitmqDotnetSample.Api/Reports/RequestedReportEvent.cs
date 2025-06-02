namespace rabbitmq_dotnet_sample.Api.Reports;

public sealed record RequestedReportEvent(Guid Id, string Name, string Description);