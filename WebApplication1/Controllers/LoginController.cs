using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous] // ---to remove authorized attribute.
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult LoginAdmin(Admin objlogin)
        {
            Class1 objclass = new Class1();
            if(ModelState.IsValid)
            {
                var admin=objclass.Admins.Where(a=>a.UserName==objlogin.UserName && a.Password==objlogin.Password).FirstOrDefault();
                if (admin != null)
                {
                    Session["AdminId"] = admin.Id;
                    Session["AdminUserName"] = admin.UserName;
                    return RedirectToAction("Dashboard", "Admin");
                }

            }
             ModelState.AddModelError("", "Invalid   user name or password");
             return RedirectToAction("LoginAdmin", "Login");

            
        }
        /*
        public ActionResult LoginAdmin(Admin objlogin)
        {
            Class1 objclass = new Class1();
            if (ModelState.IsValid)
            {
                var admin = objclass.Admins.FirstOrDefault(a => a.UserName == objlogin.UserName && a.Password == objlogin.Password);
                if (objlogin.UserName == "admin" && objlogin.Password == "admin")
                {
                    FormsAuthentication.SetAuthCookie(objlogin.UserName, false);
                    return RedirectToAction("Details", "Student");
                }
                else if (admin != null)
                {

                }

            }
            ModelState.AddModelError("", "Invalid   user name or password");
            return View(objlogin);
        }
        */
        [AllowAnonymous]
        public ActionResult LoginStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginStudent(Student student)
        {
            Class1 objclass = new Class1();
            var stu=objclass.students.Where(i=>i.Email==student.Email && i.PhoneNumber==student.PhoneNumber).FirstOrDefault();
            if (stu != null)
            {
                Session["StudentId"] = student.Id;
                Session["StudentEmail"] = student.Email;
                Session["StudentPhoneNumber"] = student.PhoneNumber;
                return RedirectToAction("Dashboard", "Student");
            }
            else
            {
                ModelState.AddModelError("", "Invalid   user name or password");
                return RedirectToAction("LoginStudent", "Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("FrontPage", "Login");
        }

        [AllowAnonymous]
        public ActionResult FrontPage()
        {
            return View();
        }

    }
}