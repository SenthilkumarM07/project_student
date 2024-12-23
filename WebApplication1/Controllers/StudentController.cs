using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [HandleError]
    public class StudentController : Controller
    {
        // GET: Student
       //[Authorize]
        public ActionResult Details()
        {
            Class1 objclass = new Class1();
            List<Student> li = objclass.students.ToList();
            return View(li); 
        }
       
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult Create(Student objStudent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Save the student to the database
                    Class1 objclass = new Class1();
                    objclass.students.Add(objStudent);
                    objclass.SaveChanges();
                    return RedirectToAction("Details"); // Redirect to Details page after successful insert
                }
                catch (DbEntityValidationException ex)
                {
                    // Log all validation errors
                    foreach (var validationError in ex.EntityValidationErrors)
                    {
                        foreach (var error in validationError.ValidationErrors)
                        {
                            // Output the error details to the console (or use your logging mechanism)
                            Console.WriteLine($"Property: {error.PropertyName}, Error: {error.ErrorMessage}");
                        }
                    }   
                    // Return an error message to the view
                    ModelState.AddModelError("", "Validation failed. Please check the input fields.");
                }
            }
            return View(objStudent);
        }

        public ActionResult Edit(int ID)
        {
            Class1 objclass = new Class1();
            Student std=objclass.students.Where(i=>i.Id==ID).FirstOrDefault();
            if (std == null)
            {
                return HttpNotFound(); // Return 404 if the student is not found
            }
            return View(std);           
        }
        [HttpPost]
        public ActionResult Edit(Student std)
        {
            Class1 objclass = new Class1();
            if (ModelState.IsValid)
            {
               var  ch=objclass.students.Where(i=>i.Id==std.Id).FirstOrDefault();
                if (ch != null)
                {
                    //objclass.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                    ch.Name = std.Name;
                    ch.Age = std.Age;
                    ch.Department = std.Department;
                    ch.Gender = std.Gender;
                    ch.Course = std.Course;
                    ch.PhoneNumber = std.PhoneNumber;
                    ch.Email = std.Email;

                    objclass.SaveChanges();
                    return RedirectToAction("Details");
                }
                else
                {
                    return HttpNotFound();
                }
            }
                return View(std);
        }

        public ActionResult Delete(int ID)
        {
            Class1 objclass = new Class1();
            var student = objclass.students.Find(ID); // Fetch the student by ID
            if (student == null)
            {
                return HttpNotFound(); // Handle if the record is not found
            }
            return View(student);
           
        }
        public ActionResult DeleteConfirmed(int ID)
        {
            Class1 objclass = new Class1();
            var student = objclass.students.Find(ID);
            if (student != null)
            {
                objclass.students.Remove(student);
                objclass.SaveChanges();
            }
            return RedirectToAction("Index");
        
            
        }
        public ActionResult Dashboard()
        {
            return View();
        }
       
        /*
        protected override void Dispose(bool disposing)
        {
            Class1 objclass = new Class1();
            if (disposing)
            {
                objclass.Dispose();
            }

            base.Dispose(disposing);
        }
        */


    }
}