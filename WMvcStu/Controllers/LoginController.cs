using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMvcPro.Models;
using WMvcPro.ViewModel;

namespace WMvcPro.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInViewModel pro)
        {
            LogInClient CC = new LogInClient();
            LogIn logIn = CC.Create(pro.logIn);
            if (logIn == null)
            {
                Session["USERID"] = null;
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                Session["USERID"] = logIn.LogInId;
                return RedirectToAction("Index", "Student");
            }
        }

        public ActionResult LogOut()
        {
            Session["USERID"] = null;
            return RedirectToAction("HomePage", "Home");
        }

    }
}