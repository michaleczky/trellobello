using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;

namespace TrelloBello.Data
{
    internal class DbContext : IDbContext
    {
        private IMongoClient _client;
        private IMongoDatabase _db;

        private IMongoCollection<Models.User> _users;
        public IMongoCollection<Models.User> Users {
            get
            {
                if (_users == null)
                {
                    _users = _db.GetCollection<Models.User>("user");
                }
                return _users;
            }
        }

        private IMongoCollection<Models.Github.Payload> _githubPayloads;
        public IMongoCollection<Models.Github.Payload> GithubPayloads
        {
            get
            {
                if (_githubPayloads == null)
                {
                    _githubPayloads = _db.GetCollection<Models.Github.Payload>("githubpayloads");
                }
                return _githubPayloads;
            }
        }

        public DbContext()
        {
            var url = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            var mongoUrl = new MongoUrl(url);
            Trace.TraceInformation("Connecting to MongoDB at " + mongoUrl.ToString());
            _client = new MongoClient(mongoUrl);
            _db = _client.GetDatabase(mongoUrl.DatabaseName);
            SeedWithInitialData();
        }

        private void SeedWithInitialData()
        {
            var bagColl = _db.GetCollection<BsonDocument>("bag");
            var seedVers = new BsonDocument("SeedVersion", "1");

            if (bagColl.Count(seedVers) == 0)
            {
                bagColl.InsertOne(seedVers);
                var user = new Models.User()
                {
                    Name = "Peter",
                    Email = "peter@domain.com",
                    UserName = "peterm"
                };
                Users.InsertOne(user);
            }
        }

    }
}