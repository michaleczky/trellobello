using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
            var db = new Data.DbContext();
            var user = await db.Users.Find(x => x.UserName == "peterm").ToListAsync();
            return Ok(user);
        }

    }
}
