using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace TrelloBello.Controllers
{
    public class TestController : ApiController
    {
        
        public async Task<IHttpActionResult> GetTest()
        {
            //var db = new Data.DbContext();
            //var user = await db.Users.Find(x => x.UserName == "peterm").ToListAsync();
            var trello = new Services.TrelloService(ConfigurationManager.AppSettings.Get("TRELLO_API_KEY"), ConfigurationManager.AppSettings.Get("TRELLO_OAUTH_TOKEN"));
            var json = trello.GetMemberInfo();
            return Ok(json);
        }

    }
}
