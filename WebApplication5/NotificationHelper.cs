using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication5
{
    public class NotificationHelper
    {
        private static readonly NotificationHubClient hubClient = NotificationHubClient.CreateClientFromConnectionString("<YourNotificationHubConnectionString>", "<YourNotificationHubName>");

        public static async Task SendNotificationAsync(string message, string tag)
        {
            var notification = new TemplateNotification(new Dictionary<string, string>
            {
                ["message"] = message
            });

            await hubClient.SendNotificationAsync(notification, tag);
        }
    }
}