using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftMovie.Controllers
{
    public class CinemaController : Controller
    {
        //
        // GET: /Cinema/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            BLL.CinemaBLL aCinema = new BLL.CinemaBLL();
            aCinema.getCinemaById(id);
            return View(aCinema);
        }

        public ActionResult Comment(int id)
        {
            BLL.CinemaComm CinemaComList = new BLL.CinemaComm();
            CinemaComList.getCCommentById(id);
            return View(CinemaComList);
        }
    }
}
