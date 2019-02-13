using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiAppl.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Web API Application";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Web API Application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact admin";

            return View();
        }
    }
}
