using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using TrelloBello.Data;

namespace TrelloBello.Controllers
{
    public class GithubController : ApiController
    {

        private IDbContext _db;

        public GithubController()
        {
            _db = new DbContext();
        }

        public async Task<IHttpActionResult> PostPayload(Models.Github.Payload payload)
        {
            await _db.GithubPayloads.InsertOneAsync(payload);
            if (payload.Commits != null)
            {
                foreach (var commit in payload.Commits)
                {
                    var cardId = _ExtractTrelloLink(commit.Message);
                    if (!String.IsNullOrEmpty(cardId))
                    {
                        var trello = new Services.TrelloService(ConfigurationManager.AppSettings.Get("TRELLO_API_KEY"), ConfigurationManager.AppSettings.Get("TRELLO_OAUTH_TOKEN"));
                        var commentText = String.Format("$Új kommit: {0}", commit.Id);
                        trello.AddCommentToCard(cardId, commentText);
                    }
                }
            }
            return Ok(new { Status = "OK", Github = payload });
        }

        public IHttpActionResult GetPayload()
        {
            var commits = _db.GithubPayloads.AsQueryable().SelectMany(x => x.Commits).ToList();
            return Ok(commits);
        }

        private string _ExtractTrelloLink(string commitMessage)
        {
            var urlExtractRegExp = @"(?:(?:https?|ftp|file):\/\/|www\.|ftp\.)(?:\([-A-Z0-9+&@#\/%=~_|$?!:,.]*\)|[-A-Z0-9+&@#\/%=~_|$?!:,.])*(?:\([-A-Z0-9+&@#\/%=~_|$?!:,.]*\)|[A-Z0-9+&@#\/%=~_|$])";
            var trelloUrlPattern = @"trello.com\/c\/(........)";
            var trelloUrl = Regex.Match(commitMessage, urlExtractRegExp, RegexOptions.IgnoreCase);
            var matches = Regex.Split(trelloUrl.Value, trelloUrlPattern, RegexOptions.IgnoreCase);
            return matches[1];
        }

    }
}
