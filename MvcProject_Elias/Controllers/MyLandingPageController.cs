using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject_Elias.Controllers
{
    public class MyLandingPageController : Controller
    {
        // GET: MyLandingPage
        public ActionResult Index()
        {
            return View();
        }
    }
}