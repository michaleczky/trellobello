using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace TrelloBello.Data
{
    internal class DbContext
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

        public DbContext()
        {
            var connUri = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            var dbName = ConfigurationManager.AppSettings.Get("DBNAME");
            _client = new MongoClient(connUri);
            _db = _client.GetDatabase(dbName);
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