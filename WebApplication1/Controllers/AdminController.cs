using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminDetails()
        {
            Class1 dbcontext = new Class1();
            List<Admin> admin = dbcontext.Admins.ToList();
            return View(admin);
        }
        public ActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                Class1 dbcontext = new Class1();
                dbcontext.Admins.Add(admin);
                dbcontext.SaveChanges();
                return RedirectToAction("AdminDetails");
            }
            return View(admin);
        }
        public ActionResult EditAdmin(int? ID)
        {
            Class1 dbcontext = new Class1();
            var admin = dbcontext.Admins.Where(i => i.Id == ID).FirstOrDefault();
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            Class1 dbcontext = new Class1();
            if (ModelState.IsValid)
            {
                var db = dbcontext.Admins.Where(i => i.Id == admin.Id).FirstOrDefault();
                if (db != null)
                {
                    db.UserName=admin.UserName;
                    db.Password = admin.Password;
                    dbcontext.SaveChanges();
                    return RedirectToAction("AdminDetails");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View(admin);
        }
        public ActionResult DeleteAdmin(int? ID)
        {
            Class1 dbcontext = new Class1();
            var db = dbcontext.Admins.Find(ID);
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (db == null)
            {
                return HttpNotFound();
            }
            return View(db);
        }
        [HttpPost, ActionName("DeleteConfirmedAdmin")]
        public ActionResult DeleteConfirmedAdmin(int ID)
        {
            Class1 dbcontext = new Class1();
            var db = dbcontext.Admins.Find(ID);
            if (db != null)
            {
                dbcontext.Admins.Remove(db); // Remove the admin
                dbcontext.SaveChanges(); // Save changes to the database
            }
            return RedirectToAction("AdminDetails");
        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}