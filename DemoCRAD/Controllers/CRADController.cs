using DemoCRAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoCRAD.Controllers
{
    public class CRADController : Controller
    {
        demoCRADEntities db = new demoCRADEntities();
        // GET: CRAD
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student model)
        {
            db.Students.Add(model);
            db.SaveChanges();

            /*string message = "Record Created Successfully";
            ViewBag.message = message;*/
            return RedirectToAction("Read");
            
        }

        [HttpGet]
        public ActionResult Read()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        public ActionResult Update(int Studentid)
        {
            var data = db.Students.Where(x => x.StudentNo == Studentid).SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(int Studentid, Student model)
        {
            var data = db.Students.FirstOrDefault(x => x.StudentNo == Studentid);
            if (data != null)
            {
                data.Name = model.Name;
                data.Email = model.Email;
                data.Branch = model.Branch;
                db.SaveChanges();
                return RedirectToAction("Read");
            }
            return View();

        }

        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int Studentid)
        {
            var data = db.Students.FirstOrDefault(x => x.StudentNo ==  Studentid);
            if (data != null)
            {
                db.Students.Remove(data);
                db.SaveChanges();
                return RedirectToAction("Read");
            }
            else
                return View();
        }
    }
}