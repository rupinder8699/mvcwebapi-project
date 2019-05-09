using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMvcStu.Models;
using WMvcStu.ViewModel;

namespace WMvcStu.Controllers
{
    public class EnrollmentController : Controller
    {
        // GET: Enrollment
        public ActionResult EnrollDet()
        {
            EnrollmentClient enro = new EnrollmentClient();
            ViewBag.listenrollment = enro.EnrollfindAll();

            return View();
        }

        public ActionResult EnrollCre()
        {
            return View("EnrollCre");
        }

        [HttpPost]
        public ActionResult EnrollCre(EnrollmentViewModel pro)
        {
            EnrollmentClient CC = new EnrollmentClient();
            CC.EnrollCre(pro.enro);
            return RedirectToAction("HomePage", "Home");
        }

    }
}