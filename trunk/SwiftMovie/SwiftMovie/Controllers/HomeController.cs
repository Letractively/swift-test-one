using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace SwiftMovie.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            //BLL.MovieBLL aMovieList = new MovieBLL();
            //ViewData["MovieList"] = aMovieList;

            //BLL.CinameBLL

            //List<Model.Cinema> a = new List<Cinema>() ;
            //a.Add(new Cinema() { CinemaName="黑衣人II" });
            //ViewData["Cinemas"] = a;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }


        //
        // GET: /Index/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Index/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Index/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Index/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Index/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Index/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Index/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
