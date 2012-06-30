using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PlayTime
    {
        public int PlaytimeID { get; set; }
        public int MovieID { get; set; }
        public int CinemaID { get; set; }
        public DateTime Playtime { get;set; }
        public bool PlayState { get; set; }
    }
}
