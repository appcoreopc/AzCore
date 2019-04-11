using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzUploader
{
    public static class GetSharedAccessUrl
    {
        [FunctionName("GetSharedAccessUrl")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("Getting request to generate shared access url for a blob storage.");
            var file = req.GetQueryNameValuePairs().FirstOrDefault(x => x.Key == "filename").Value;

            var storageAccount = CloudStorageAccount.Parse(System.Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING", System.EnvironmentVariableTarget.Process));

            
            return req.CreateResponse(HttpStatusCode.OK, "Hello there!");
        }
    }
}
