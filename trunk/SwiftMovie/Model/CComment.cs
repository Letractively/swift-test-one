using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CComment
    {
        public int CCommentID { get; set; }
        public int CinemaID { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public DateTime CommTime { get; set; }
        public float Grade { get; set; }
    }
}
