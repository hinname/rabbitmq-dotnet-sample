namespace rabbitmq_dotnet_sample.Api.Reports.Response;

public class ResponseRequestedReport
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime? ProcessedTime { get; set; } = null;
}