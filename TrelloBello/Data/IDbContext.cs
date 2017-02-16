using MongoDB.Bson;
using MongoDB.Driver;
using TrelloBello.Models;

namespace TrelloBello.Data
{
    internal interface IDbContext
    {
        IMongoCollection<Models.Github.Payload> GithubPayloads { get; }
        IMongoCollection<Models.User> Users { get; }
    }
}