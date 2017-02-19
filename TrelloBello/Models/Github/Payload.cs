using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrelloBello.Models.Github
{
    public class Payload : IMongoEntity
    {
        [BsonId]
        public ObjectId _Id { get; set; }
        public IEnumerable<Commit> Commits { get; set; }
        public string Ref { get; set; }
    }
}