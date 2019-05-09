using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMvcStu.Models;
using WMvcStu.ViewModel;

namespace WMvcStu.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentClient product = new StudentClient();
            ViewBag.listStudents = product.findAll();

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(StudentViewModel pro)
        {
            StudentClient CiC = new StudentClient();
            CiC.Create(pro.student);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            StudentClient CC = new StudentClient();
            CC.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            StudentClient prod = new StudentClient();
            StudentViewModel studentView = new StudentViewModel();
            studentView.student = prod.find(id);
            return View("Edit", studentView);
        }
        [HttpPost]
        public ActionResult Edit(StudentViewModel studentView)
        {
            StudentClient CC = new StudentClient();
            CC.Edit(studentView.student);
            return RedirectToAction("Index");
        }

    }
}