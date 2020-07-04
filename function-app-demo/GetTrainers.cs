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
using System.Linq;
using System.Collections.Generic;
using DemoAzureServerless.Models;

namespace DemoAzureServerless
{
    public static class GetTrainers
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

        [FunctionName("GetTrainers")]
        public static async Task<List<Trainer>> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var returnList = client.CreateDocumentQuery<Trainer>(trainerCollectionUri, trainerQueryOptions).ToList();
            return returnList;
        }
    }
}
