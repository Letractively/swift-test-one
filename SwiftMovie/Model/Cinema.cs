using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Cinema
    {
        public int CinemaID { get; set; }
        public string CinemaName { get; set; }
        public string Address { get; set; }
        public string CinemaMap { get; set; }
        public string CinemaTel { get; set; }
        public string CinemaGrade { get; set; }
        public string Privilege { get; set; }
        public string VIP { get; set; }
        public string Dining { get; set; }
        public string Park { get; set; }
        public string GameCenter { get; set; }
        public string Intro3D { get; set; }
        public string IntroVIP { get; set; }
        public string Introduce { get; set; }
        public List<CinemaPic> CinemaPic { get; set; }
        
    }
}
