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
            int isSuccess = 0;
            isSuccess = user.register(form["username"], form["password"], form["email"], form["address"]);
            ViewData["isSuccess"] = isSuccess;
            return View();


        }
        // 登录
        public ActionResult Login()
        { 
            return View(); 
        }
        // 登录
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            BLL.UserBLL user = new BLL.UserBLL();
            bool isSuccess;
            isSuccess = user.login(form["username"], form["password"]);
            ViewData["isSuccess"] = isSuccess;
            return View(); 
        }
    }
}
