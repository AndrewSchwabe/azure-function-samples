using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Schedule.Functions
{
    public class ScheduleFunction
    {
        [FunctionName("websiteping")]
        public async Task Run(
            [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
            ILogger log)
        {
            var client = HttpClientFactory.Create();
            log.LogInformation("HttpClient Created");

            var response = await client.GetAsync(new Uri("https://google.com"));

            if (!response.IsSuccessStatusCode) log.LogCritical($"Website ping recieved unsuccessful response of: {response.StatusCode}");
            log.LogInformation($"Website ping recieved successful response of: {response.StatusCode}");
        }
    }
}
