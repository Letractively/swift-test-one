using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace SwiftMovie.Controllers
{
    public class MovieController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail()
        {
            int id = int.Parse(Request["id"].ToString());
            Model.Movie m =(new BLL.MovieBLL()).getMovieByID(id);
            ViewData["Movie"] = m;

            List<Model.Play> plays = (new BLL.PlayBLL()).getPlayList(m.MovieID);
            Hashtable ht = new Hashtable();
            foreach (Model.Play play in plays)
            {
                if(!ht.ContainsKey(play.CinemaID))
                    ht[play.CinemaID] = play;
            }
            List<Model.Cinema> cinemas = new List<Model.Cinema>();
            foreach (var item in ht.Values)
            {
                Model.Play play = (Model.Play)item;
                Model.Cinema cinema = (new BLL.CinemaBLL()).getCinemaById(play.CinemaID);
                cinemas.Add(cinema);
            }
            ViewData["Plays"] = plays;
            ViewData["Cinemas"] = cinemas;
            return View();
        }

        public ActionResult Comment()
        {
            return View();
        }

    }
}
