using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDWithIssues.Models;

namespace CRUDWithIssues.Controllers
{
    public class StudentsController : Controller
    {
        private StudentContext db = new StudentContext();

        public ActionResult Index()
        {
            return View(StudentDB.GetStudents(db));
        }

        public ActionResult Details(int? id)
        {
            //make sure an id value is passed in
            if (id == null)
            {
                //return error page if no id was passed in
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = StudentDB.GetStudent(db, id.Value);
            
            //if student was not found, return not found error page
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentDB.AddStudent(db, student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Edit(int? id)
        {
            //make sure an id is passed in or return error
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = StudentDB.GetStudent(db, id.Value);

            //if student not found return not found page
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentDB.UpdateStudent(db, student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = StudentDB.GetStudent(db, id.Value);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = StudentDB.GetStudent(db, id);
            StudentDB.DeleteStudent(db, student);
            return RedirectToAction("Index");
        }

        //ensures database is disposed of
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
