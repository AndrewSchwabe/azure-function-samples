using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Cosmos.Functions
{
    public static class CosmosAudit
    {
        [FunctionName("CosmosAudit")]
        public static void Run([CosmosDBTrigger(
            databaseName: "FunctionContainer",
            collectionName: "person",
            ConnectionStringSetting = "CosmosConnectionString",
            CreateLeaseCollectionIfNotExists = true)]IReadOnlyList<Document> peopleDocuments,
            ILogger log)
        {
            if (peopleDocuments != null && peopleDocuments.Count > 0)
            {
                log.LogInformation($"Documents Audited : {peopleDocuments.Count}");

                foreach (var personDocument in peopleDocuments)
                {
                    log.LogInformation($"{personDocument.Id} : {personDocument.GetPropertyValue<string>("firstName")} : {personDocument.GetPropertyValue<string>("lastName")}");
                }
            }
        }
    }
}
