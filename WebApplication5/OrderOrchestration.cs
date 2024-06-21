using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using WebApplication5;

public static class OrderOrchestration
{
    [FunctionName("PlaceOrder")]
    public static async Task<IActionResult> PlaceOrder(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        [DurableClient] IDurableOrchestrationClient starter,
        ILogger log)
    {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var orderDetails = JsonConvert.DeserializeObject<OrderDetails>(requestBody);

        string instanceId = await starter.StartNewAsync("OrderOrchestrator", orderDetails);

        log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

        HttpRequestMessage httpRequestMessage = HttpRequestHelper.ConvertHttpRequestToHttpRequestMessage(req);
        HttpResponseMessage httpResponseMessage = starter.CreateCheckStatusResponse(httpRequestMessage, instanceId);

        // Wrap HttpResponseMessage into IActionResult
        return new ObjectResult(httpResponseMessage)
        {
            StatusCode = (int)httpResponseMessage.StatusCode
        };
    }

    [FunctionName("OrderOrchestrator")]
    public static async Task OrderOrchestrator(
        [OrchestrationTrigger] IDurableOrchestrationContext context)
    {
        var orderDetails = context.GetInput<OrderDetails>();

        await context.CallActivityAsync("UpdateInventory", orderDetails);
        await context.CallActivityAsync("ProcessPayment", orderDetails);
        await context.CallActivityAsync("SendOrderConfirmation", orderDetails);
    }

    [FunctionName("UpdateInventory")]
    public static async Task UpdateInventory([ActivityTrigger] OrderDetails orderDetails, ILogger log)
    {
        log.LogInformation($"Updating inventory for order {orderDetails.OrderId}");
        // Simulate inventory update
        await Task.Delay(1000);
    }

    [FunctionName("ProcessPayment")]
    public static async Task ProcessPayment([ActivityTrigger] OrderDetails orderDetails, ILogger log)
    {
        log.LogInformation($"Processing payment for order {orderDetails.OrderId}");
        // Simulate payment processing
        await Task.Delay(1000);
    }

    [FunctionName("SendOrderConfirmation")]
    public static async Task SendOrderConfirmation([ActivityTrigger] OrderDetails orderDetails, ILogger log)
    {
        log.LogInformation($"Sending order confirmation for order {orderDetails.OrderId}");
        // Simulate sending confirmation
        await Task.Delay(1000);
    }
}

public class OrderDetails
{
    public string OrderId { get; set; }
    public string ProductId { get; set; }
    public string UserId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
}
