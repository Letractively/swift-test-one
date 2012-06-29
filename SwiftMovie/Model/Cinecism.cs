using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Cinecism
    {
        public int CinecismID { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public DateTime CommTime { get; set; }
        public int MovieID { get; set; }
    }
}
