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
        private RestClient client;   

        public TrelloService(string apiKey, string accessToken)
        {
            this.apiKey = apiKey;
            this.accessToken = accessToken;
            this.client = new RestClient("https://api.trello.com/1/");
        }

        public string GetMemberInfo()
        {
            var request = new RestRequest("members/me", Method.GET);
            request.AddQueryParameter("key", apiKey);
            request.AddQueryParameter("token", accessToken);
            var response = client.Execute(request);
            return response.Content;            
        }

        public string AddCommentToCard(string cardIdOrShortLink, string commentText)
        {
            var request = new RestRequest("cards/{id}/actions/comments", Method.POST);
            request.AddUrlSegment("id", cardIdOrShortLink);            
            request.AddParameter("key", apiKey, ParameterType.GetOrPost);
            request.AddParameter("token", accessToken, ParameterType.GetOrPost);
            request.AddParameter("text", commentText, ParameterType.GetOrPost);
            var response = client.Execute(request);
            return response.Content;
        }

    }
}