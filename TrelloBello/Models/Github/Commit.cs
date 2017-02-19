using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrelloBello.Models.Github
{
    public class Commit: IMongoEntity
    {
        public ObjectId _Id { get; set; }
        public string Id { get; set; }
        public string Message { get; set; }
        public Committer Committer { get; set; }
        public string Url { get; set; }
    }
}