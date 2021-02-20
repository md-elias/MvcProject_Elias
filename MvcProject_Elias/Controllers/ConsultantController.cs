using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcProject_Elias;
using System.Data.Entity;
using MvcProject_Elias.Models;

namespace MvcProject_Elias.Controllers
{
    public class ConsultantController : Controller
    {
        // GET: Consultant
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }

        IEnumerable<Consultant> GetAllEmployee()
        {
            using (MvcProject_EliasDBEntities db = new MvcProject_EliasDBEntities())
            {
                return db.Consultants.ToList<Consultant>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Consultant emp = new Consultant();
            if (id != 0)
            {
                using (MvcProject_EliasDBEntities db = new MvcProject_EliasDBEntities())
                {
                    emp = db.Consultants.Where(x => x.ConsultantID == id).FirstOrDefault<Consultant>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Consultant emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }
                using (MvcProject_EliasDBEntities db = new MvcProject_EliasDBEntities())
                {
                    if (emp.ConsultantID == 0)
                    {
                        db.Consultants.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (MvcProject_EliasDBEntities db = new MvcProject_EliasDBEntities())
                {
                    Consultant emp = db.Consultants.Where(x => x.ConsultantID == id).FirstOrDefault<Consultant>();
                    db.Consultants.Remove(emp);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}