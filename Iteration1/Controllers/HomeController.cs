using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iteration1.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult SinglePlayer()
        {
            ViewBag.Message = "Single-Player game of Don";

            return View();
        }
        [Authorize]
        public ActionResult MultiPlayer()
        {
            ViewBag.Message = "Multi-Player game of Don";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}