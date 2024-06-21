using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication5;

public static class ProductChangeNotifier
{
    [FunctionName("NotifyProductChanges")]
    public static async Task<IActionResult> NotifyProductChanges(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        [DurableClient] IDurableOrchestrationClient starter,
        ILogger log)
    {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var notificationDetails = JsonConvert.DeserializeObject<NotificationDetails>(requestBody);

        string instanceId = await starter.StartNewAsync("ProductChangeOrchestrator", notificationDetails);

        log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

        // Convert HttpRequest to HttpRequestMessage
        HttpRequestMessage httpRequestMessage = HttpRequestHelper.ConvertHttpRequestToHttpRequestMessage(req);
        HttpResponseMessage httpResponseMessage = starter.CreateCheckStatusResponse(httpRequestMessage, instanceId);

        // Wrap HttpResponseMessage into IActionResult
        return new ObjectResult(httpResponseMessage)
        {
            StatusCode = (int)httpResponseMessage.StatusCode
        };
    }

    [FunctionName("ProductChangeOrchestrator")]
    public static async Task ProductChangeOrchestrator(
        [OrchestrationTrigger] IDurableOrchestrationContext context)
    {
        var notificationDetails = context.GetInput<NotificationDetails>();

        await context.CallActivityAsync("SendProductUpdateNotifications", notificationDetails);
    }

    [FunctionName("SendProductUpdateNotifications")]
    public static async Task SendProductUpdateNotifications([ActivityTrigger] NotificationDetails notificationDetails, ILogger log)
    {
        log.LogInformation($"Sending product update notifications for product {notificationDetails.ProductId}");
        // Simulate sending notifications
        await Task.Delay(1000);
    }
}

public class NotificationDetails
{
    public string ProductId { get; set; }
    public string UpdateType { get; set; }
    public string Message { get; set; }
}
