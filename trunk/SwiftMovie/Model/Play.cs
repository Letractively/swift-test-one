using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Play
    {
        public int PlayID { get; set; }
        public string PlayName { get; set; }
        public int MovieID { get; set; }
        public int CinemaID { get; set; }
        public float Price { get; set; }
    }
}
