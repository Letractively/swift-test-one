using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SpiderDAL;
using Model;

namespace SystemBLL
{
    public class SaveMovie
    {
        public static bool saveMovie(string url)
        {
            bool success = false;
            MovieSpider ms = new MovieSpider();
            string html = File.ReadAllText(url);
            int movieID = ms.getMovieID(url);
            string movieName = ms.getMovieName(html);
            string coverURL = ms.getCoverURL(html);
            string director = ms.getDirector(html);
            string protagonist = ms.getProtagonist(html);
            string movieType = ms.getMovieType(html);
            DateTime releaseDate = ms.getReleaseDate(html);
            string runTime = ms.getRunTime(html);

            Movie movie = new Movie()
            {
                MovieID = movieID,
                MovieName = movieName,
                CoverURL = coverURL,
                Director = director,
                Protagonist = protagonist,
                Type = movieType,
                ReleaseDate = releaseDate,
                RunTime = runTime
            };

            IDAL.IMovie movieDal = DALFactory.DataAccess.createDalMovie();
            if (movieDal.getMovieById(movieID) == null)
            {
                success = movieDal.addMovie(movie);
            }
            return success;
        }
    }
}
