using Microsoft.AspNetCore.Http.HttpResults;
using rabbitmq_dotnet_sample.Api.Extensions;
using rabbitmq_dotnet_sample.Api.Reports;
using rabbitmq_dotnet_sample.Api.Reports.Response;

namespace rabbitmq_dotnet_sample.Api.Controllers;

public static class ApiEndpoints
{
    public static void AddApiEndpoints(this WebApplication app)
    {
        app.MapPost("/api/report", (string name, string description) =>
        {

            var report = new RequestedReport
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Status = Status.Pending
            };
            
            

            // Here you would typically send the report to a message queue for processing
            ReportsList.Reports.Add(report);
            
            
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