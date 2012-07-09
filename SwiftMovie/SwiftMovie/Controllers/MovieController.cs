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
            List<Model.Movie> movies = new List<Model.Movie>();
            //ViewData["Movies"] = movies.Take(10).ToList();

            List<Model.Play> plays = (new BLL.PlayBLL()).getPlayList();
            Hashtable ht = new Hashtable();
            foreach (Model.Play play in plays)
            {
                if (!ht.ContainsKey(play.MovieID))
                    ht[play.MovieID] = play;
            }
            foreach (var item in ht.Values)
            {
                Model.Play play = (Model.Play)item;
                Model.Movie movie = (new BLL.MovieBLL()).getMovieByID(play.MovieID);
                movies.Add(movie);
            }
            ViewData["PlayMovies"] = movies.Take(10).ToList();

            List<Model.PlayTime> playTimes = (new BLL.PlayTimeBLL()).getPlayTimeList();
            List<Model.Movie> soonMovies = new List<Model.Movie>();
            Hashtable ht2 = new Hashtable();
            foreach (Model.PlayTime playTime in playTimes)
            {
                if (!ht2.ContainsKey(playTime.MovieID))
                    ht2[playTime.MovieID] = playTime;
            }
            foreach (var item in ht2.Values)
            {
                Model.PlayTime playTime = (Model.PlayTime)item;
                Model.Movie movie = (new BLL.MovieBLL()).getMovieByID(playTime.MovieID);
                soonMovies.Add(movie);
            }
            ViewData["SoonMovies"] = soonMovies.Take(10).ToList();

            List<Model.Cinecism> cinecisms = (new BLL.CinecismBLL()).getCinecismList();
            ViewData["Cinecisms"] = cinecisms.Take(30).ToList();
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
                    if (!ht.ContainsKey(play.CinemaID))
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

        public ActionResult Soon()
        {
            int id = int.Parse(Request["id"].ToString());
            Model.Movie m = (new BLL.MovieBLL()).getMovieByID(id);
            ViewData["Movie"] = m;

            List<Model.PlayTime> playTimes = (new BLL.PlayTimeBLL()).getPlayTimeList(id);
            Hashtable ht = new Hashtable();
            foreach (Model.PlayTime playTime in playTimes)
            {
                if (!ht.ContainsKey(playTime.CinemaID))
                    ht[playTime.CinemaID] = playTime;
            }
            List<Model.Cinema> cinemas = new List<Model.Cinema>();
            foreach (var item in ht.Values)
            {
                Model.PlayTime playTime = (Model.PlayTime)item;
                Model.Cinema cinema = (new BLL.CinemaBLL()).getCinemaById(playTime.CinemaID);
                cinemas.Add(cinema);
            }
            ViewData["Cinemas"] = cinemas;
            return View();
        }

        public ActionResult Comment()
        {
            return View();
        }

    }
}
