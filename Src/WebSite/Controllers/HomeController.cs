using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index() {
            return Content("Hello " + Request.QueryString["name"] + "...." + Request.QueryString["age"]
                );
        }

        [HttpHead]
        public ActionResult Head() {
            return Content("Hello World " + Request.QueryString["name"] + "...." + Request.QueryString["age"]);
        }

        [HttpPost]
        public ActionResult Post(string name, int age) {
            return Content("Hello " + name + ":" + age);
        }

        [HttpPatch]
        public ActionResult Patch() {
            return Content("Hello " + Request.Form["name"] + ":" + Request.Form["age"]);
        }

        [HttpPut]
        public ActionResult Put(string name, int age) {
            return Content("Hello " + name + ":" + age);
        }

        [HttpDelete]
        public ActionResult Delete() {
            return Content("Hello " + Request.Form["name"] + ":" + Request.Form["age"]);
        }

        [HttpPost]
        public ActionResult Upload() {

            if (Request.Files.Count > 0) {

                if(!System.IO.Directory.Exists(Request.MapPath("~/tmp/"))){
                    System.IO.Directory.CreateDirectory(Request.MapPath("~/tmp/"));
                }

                var file = Request.Files[0];

                file.SaveAs(Request.MapPath("~/tmp/") + file.FileName);

                return Content(Request.Form["name"] + ";age:" + Request.Form["age"] + ":" + System.IO.File.ReadAllText(Request.MapPath("~/tmp/") + file.FileName));
            }

            return Content("no file");
        }

    }
}
