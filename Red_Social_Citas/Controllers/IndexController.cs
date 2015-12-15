using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Red_Social_Citas.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.error = Request["error"];
            return View();
        }
    }
}
