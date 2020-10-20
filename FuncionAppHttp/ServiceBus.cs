using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FuncionAppHttp
{
    public static class ServiceBus
    {
        [FunctionName("ServiceBus")]
        public static void Run([ServiceBusTrigger("queue01", Connection = "CONNECTION_STRING_SERVICE_BUS")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function message: {myQueueItem}");
        }
    }
}
