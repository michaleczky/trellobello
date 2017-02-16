using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloBello.Models
{
    interface IMongoEntity
    {
        ObjectId _Id { get; set; }
    }
}
