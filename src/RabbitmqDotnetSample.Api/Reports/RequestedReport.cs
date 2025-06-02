namespace rabbitmq_dotnet_sample.Api.Reports;

public class RequestedReport
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Status Status { get; set; } = Status.Pending;
    public DateTime? ProcessedTime { get; set; } = null;
}