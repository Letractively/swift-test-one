﻿using System;
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
           List<Model.Movie> aMovieList = (new MovieBLL()).getMovieList();
            ViewData["MovieList"] = aMovieList.Take(8).ToList();

            List<Model.Cinema> cinemaList = (new CinemaBLL()).getCinemaList();

            ViewData["Cinemas"] = (from s in cinemaList
                    where s.CinemaPic != null
                    orderby s.CinemaGrade descending
                    select s).Take(3).ToList();
            

            return View();
        }
        public ActionResult Search()
        {
            string name = Request["content"].ToString();
            List<Model.Movie> MovieList = (new MovieBLL()).getMovieListByName(name);
            ViewData["SearchMovies"] = MovieList.ToList();
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
