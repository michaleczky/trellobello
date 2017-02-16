using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            return Ok(new { Status = "OK", Payload = payload});
        }

        public IHttpActionResult GetPayload()
        {
            var commits = _db.GithubPayloads.AsQueryable().SelectMany(x => x.Commits).ToList();
            return Ok(commits);
        }

    }
}
