using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrelloBello.Models.Github
{
    public class Committer: IMongoEntity
    {        
        public ObjectId _Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}