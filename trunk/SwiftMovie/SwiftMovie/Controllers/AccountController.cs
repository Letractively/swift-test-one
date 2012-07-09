using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SwiftMovie.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/


        // 注册
        public ActionResult Reg()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reg(FormCollection form)
        {
            BLL.UserBLL user = new BLL.UserBLL();
            int isSuccess ;
            isSuccess = user.register(form["username"], form["password"], form["email"], form["address"]);
            

            ViewData["isSuccess"] = isSuccess;
            return View();


        }
        
        public ActionResult Login()
        { 
            return View(); 
        }

        
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            BLL.UserBLL user = new BLL.UserBLL();
            bool isSuccess;
            isSuccess = user.login(form["username"], form["password"]);
            string message;
            if (isSuccess == true)
            {
                
                
            }
            ViewData["isSuccess"] = isSuccess;
            return View(); 
        }
    }
}
