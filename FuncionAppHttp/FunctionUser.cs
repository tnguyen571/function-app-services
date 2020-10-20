using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using FuncionAppHttp.Model;

namespace FuncionAppHttp
{
    public static class FunctionUser
    {
        [FunctionName("FunctionUser")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            List<User> users = null;
            if (name.Equals("userData"))
            {

                users = new List<User>
                {
                    new User() { FirstName = "user1", Id = 2, LastName = "user1", Username = "user1", Password = "user1" },
                    new User() { FirstName = "user2", Id = 3, LastName = "user2", Username = "user3", Password = "user2" }
                };
            }

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : JsonConvert.SerializeObject(users);

            return new OkObjectResult(responseMessage);
        }
    }
}
