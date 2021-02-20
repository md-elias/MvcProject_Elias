using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcProject_Elias.Models;

namespace MvcProject_Elias.Controllers
{
    public class TraineController : Controller
    {
        private MvcProject_EliasDBEntities db = new MvcProject_EliasDBEntities();

        // GET: Traine
        public ActionResult Index()
        {
            return View(db.Traines.ToList());
        }

        // GET: /Traine/Details/5

        public ActionResult Details(int id = 0)
        {
            Traine traine = db.Traines.Find(id);
            if (traine == null)
            {
                return HttpNotFound();
            }
            return View(traine);
        }

        public JsonResult ExamDetails(int id)
        {
            var examInfo = db.ExamDetails.Where(e => e.TraineId == id).AsEnumerable().Select(a =>
                new
                {
                    id = a.ExamDetailsID,
                    examName = a.ExamName,
                    examDate = a.ExamDate.ToString("dd-MM-yyyy"),
                    resultDate = a.ResultPublishDate.ToString("dd-MM-yyyy"),
                    totalMarks = a.Total
                });
            return Json(examInfo, JsonRequestBehavior.AllowGet);
        }


        //
        // GET: /Traine/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Traine/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Traine traine)
        {
            if (ModelState.IsValid)
            {
                db.Traines.Add(traine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(traine);
        }

        //
        // GET: /Traine/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Traine traine = db.Traines.Find(id);
            if (traine == null)
            {
                return HttpNotFound();
            }
            return View(traine);
        }

        //
        // POST: /Traine/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Traine traine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(traine);
        }

        //
        // GET: /Trainee/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Traine traine = db.Traines.Find(id);
            if (traine == null)
            {
                return HttpNotFound();
            }
            return View(traine);
        }

        //
        // POST: /Trainee/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Traine traine = db.Traines.Find(id);
            db.Traines.Remove(traine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}