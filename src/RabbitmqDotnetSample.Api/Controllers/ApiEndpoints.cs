using Microsoft.AspNetCore.Mvc;
using rabbitmq_dotnet_sample.Api.Bus;
using rabbitmq_dotnet_sample.Api.Extensions;
using rabbitmq_dotnet_sample.Api.Reports;
using rabbitmq_dotnet_sample.Api.Reports.Response;

namespace rabbitmq_dotnet_sample.Api.Controllers;

public static class ApiEndpoints
{
    public static void AddApiEndpoints(this WebApplication app)
    {
        app.MapPost("/api/report", async (string name, string description, 
            [FromServices] IProjectPublishBus bus,
            CancellationToken ct = default) =>
        {

            var report = new RequestedReport
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Status = Status.Pending
            };
            
            ReportsList.Reports.Add(report);
            
            // Publish the report to the bus
            var eventRequest = new RequestedReportEvent(report.Id, report.Name, report.Description);
            await bus.PublishAsync(eventRequest, ct);
            
            // Convert to ResponseRequestedReport
            var responseReport = new ResponseRequestedReport
            {
                Id = report.Id,
                Name = report.Name,
                Description = report.Description,
                Status = report.Status.StatusToString(),
                ProcessedTime = report.ProcessedTime
            };
            return Results.Ok(responseReport);
        });
        
        app.MapGet("/api/report", () => Results.Ok(ReportsList.Reports));
    }
}