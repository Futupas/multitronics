using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multitronics.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //
        public ActionResult SomeProduct()
        {
            ViewBag.id = RouteData.Values["id"].ToString();
            return View();
        }
        //
        public ActionResult Product()
        {
            return Redirect(Url.Action("Products", "Home"));
        }
        //
        public ActionResult Products()
        {
            return View();
        }
    }
}
