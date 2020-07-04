using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Documents.Client;

namespace DemoAzureServerless
{
    public static class SubmitTrainerApplication
    {
        #region Secret Section: recommended to be moved to Azure Vault

        // The Azure Cosmos DB endpoint for running this sample.
        private static readonly string EndpointUri = "https://leophamdemodb.documents.azure.com:443/";
        // The primary key for the Azure Cosmos account.
        private static readonly string PrimaryKey = "6WnFO1E6mLU2vGUg2VEeeLUULlumaNiPUpRoRVoGy6DLWFzf8d8j8lhpUxMCfABpctwGTbGizdSUCSFN3Nl5jQ==";

        #endregion

        private static DocumentClient client = new DocumentClient(new Uri(EndpointUri),PrimaryKey);

        private static string databaseId = "azureserverlessdemo";
        private static string collectionId = "trainers";
        private static Uri trainerCollectionUri = UriFactory.CreateDocumentCollectionUri(databaseId,collectionId);

        private static readonly FeedOptions trainerQueryOptions = new FeedOptions { MaxItemCount = -1 };


        [FunctionName("SubmitTrainerApplication")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // var returnList = client.CreateDocumentQuery<Trainer>(trainerCollectionUri, trainerQueryOptions).ToList();
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
        
            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
