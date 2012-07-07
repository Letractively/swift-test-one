using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftMovie.Controllers
{
    public class CinemaController : Controller
    {
        //
        // GET: /Cinema/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Comment(int id)
        {
            return View();
        }
    }
}
