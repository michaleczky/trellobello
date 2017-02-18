using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace TrelloBello.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Integ_TrelloService_AddComment()
        {            
            var apiKey = ConfigurationManager.AppSettings.Get("TRELLO_API_KEY");
            var token = ConfigurationManager.AppSettings.Get("TRELLO_OAUTH_TOKEN");
            var testCardId = ConfigurationManager.AppSettings.Get("TrelloTestCardId");
            var trello = new Services.TrelloService(apiKey, token);
            var result = trello.AddCommentToCard(testCardId, "$Új kommit:123455667891132(testbranch)\n$unittest run)");
            var json = JObject.Parse(result);
        }

    }
}
