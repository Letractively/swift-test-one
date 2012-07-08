using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftMovie.Controllers
{
    public class MovieController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            Model.Movie m =(new BLL.MovieBLL()).getMovieByID(id);
            ViewData["Movie"] = new Model.Movie() { MovieName = "123", MovieID = 2 };//m;
            return View();
        }

    }
}
