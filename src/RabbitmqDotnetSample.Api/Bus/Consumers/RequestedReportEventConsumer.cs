using MassTransit;
using rabbitmq_dotnet_sample.Api.Reports;

namespace rabbitmq_dotnet_sample.Api.Bus.Consumers;

public class RequestedReportEventConsumer : IConsumer<RequestedReportEvent>
{
    private readonly ILogger<RequestedReportEventConsumer> _logger;
    public RequestedReportEventConsumer(ILogger<RequestedReportEventConsumer> logger)
    {
        _logger = logger;
    }
    
    public async Task Consume(ConsumeContext<RequestedReportEvent> context)
    {
        var message = context.Message;
        _logger.LogInformation("RequestedReportEventConsumer: {Id} - {Name} - {Description}", 
            message.Id, context.Message.Name, context.Message.Description);

        // Simulate processing the report request
        await Task.Delay(10000);
        
        var report = ReportsList.Reports.FirstOrDefault(r => r.Id == message.Id);
        if (report != null)
        {
            report.Status = Status.Completed;
            report.ProcessedTime = DateTime.Now;
        }
        else
        {
            _logger.LogWarning("Report with Id {Id} not found", message.Id);
        }
        _logger.LogInformation("Report processing completed for {Id} - {Name} - {Description}", 
            message.Id, message.Name, message.Description);
    }
}