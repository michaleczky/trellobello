using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrelloBello.Services
{
    public class TrelloService
    {

        private string apiKey;
        private string accessToken;        

        public TrelloService(string apiKey, string accessToken)
        {
            this.apiKey = apiKey;
            this.accessToken = accessToken;
        }

        public JObject GetMemberInfo()
        {
            var client = new RestClient("http://api.trello.com/1/members/me");
            var request = new RestRequest(Method.GET);
            request.AddQueryParameter("key", apiKey);
            request.AddQueryParameter("token", accessToken);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            return JObject.Parse(response.Content);
        }

    }
}