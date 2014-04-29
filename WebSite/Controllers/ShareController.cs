using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace WebSite.Controllers
{
    public class ShareController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Index([FromBody] TransConfig config) {
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(config.Name + ":" + config.Age, Encoding.UTF8, "application/json")
            };
        }

        [HttpGet]
        public HttpResponseMessage Head() {
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent("asdasd", Encoding.UTF8, "application/json")
            };
        }
    }
}