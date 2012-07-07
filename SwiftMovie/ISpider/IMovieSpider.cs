using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISpider
{
    public interface IMovieSpider
    {
        int getMovieID(string url);
        string getMovieName(string html);
        string getCoverURL(string html);
        string getDirector(string html);
        string getProtagonist(string html);
        string getMovieType(string html);
        DateTime getReleaseDate(string html);
        float getRunTime(string html);
    }
}
