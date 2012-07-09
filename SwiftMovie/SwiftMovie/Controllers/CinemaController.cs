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

        public ActionResult Detail()
        {
            int cinemaID = int.Parse(Request["id"].ToString());
            Model.Cinema cinema = (new BLL.CinemaBLL()).getCinemaById(cinemaID);
            ViewData["Cinema"] = cinema;
            return View();
        }

        //public ActionResult Detail(int id)
        //{
        //    return View();
        //}

        public ActionResult Comment(int id)
        {
            return View();
        }
    }
}
