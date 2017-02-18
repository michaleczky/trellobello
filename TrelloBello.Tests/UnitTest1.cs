using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using TrelloBello.Models.Github;

namespace TrelloBello.Tests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void Integ_TrelloService_AddComment()
        //{            
        //    var apiKey = ConfigurationManager.AppSettings.Get("TRELLO_API_KEY");
        //    var token = ConfigurationManager.AppSettings.Get("TRELLO_OAUTH_TOKEN");
        //    var testCardId = ConfigurationManager.AppSettings.Get("TrelloTestCardId");
        //    var trello = new Services.TrelloService(apiKey, token);
        //    var result = trello.AddCommentToCard(testCardId, "$Új kommit:123455667891132(testbranch)\n$unittest run)");
        //    var json = JObject.Parse(result);
        //}

        //[TestMethod]        
        //[DeploymentItem("github_payload.json")]
        //public void Integ_Github_Webhook()
        //{
        //    var payloadJson = System.IO.File.ReadAllText("github_payload.json");
        //    var payload = JsonConvert.DeserializeObject<Models.Github.Payload>(payloadJson);
        //    var controller = new Controllers.GithubController();
        //    var task = controller.PostPayload(payload);
        //    task.Wait();
        //    var result = task.Result;
        //}

    }
}
