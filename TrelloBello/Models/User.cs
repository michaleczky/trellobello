﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrelloBello.Models
{
    public class User: IMongoEntity
    {
        public ObjectId _Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}