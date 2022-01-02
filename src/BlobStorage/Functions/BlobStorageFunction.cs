using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace BlobStorage
{
    public class BlobStorageFunction
    {
        [FunctionName("BlobAudit")]
        public void Run(
            [BlobTrigger("sample/{name}")]Stream blobStream,
            string name,
            ILogger log)
        {
            log.LogInformation($"File uploaded to 'sample' container with filename: {name}");
        }
    }
}
