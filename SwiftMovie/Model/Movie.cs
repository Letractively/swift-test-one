using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string CoverURL { get; set; }
        public string Director { get; set; }
        public string Protagonist { get; set; }
        public string Type { get; set; }
        public string ReleaseDate { get; set; }
        public string RunTime { get; set; }
    }
}
