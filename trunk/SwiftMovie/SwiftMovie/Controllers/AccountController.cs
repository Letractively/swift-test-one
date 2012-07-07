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

        // 登录
        public ActionResult Login()
        { 
            
            return View(); 
        }
    }
}
