using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TimeTableController : Controller
    {
        private Class1 context = new Class1();
        // GET: TimeTable
        public List<Timetable> mockimetable = new List<Timetable>()
        {
            new Timetable { Id = 1, Day = "Monday", Subject = "Mathematics", Time = "10:00 AM - 11:00 AM", Teacher = "Mr. A Kumar" },
            new Timetable { Id = 2, Day = "Monday", Subject = "Physics", Time = "11:15 AM - 12:15 PM", Teacher = "Dr. B Sharma" },
            new Timetable { Id = 3, Day = "Tuesday", Subject = "Chemistry", Time = "09:00 AM - 10:00 AM", Teacher = "Ms. C Singh" },
            new Timetable { Id = 4, Day = "Wednesday", Subject = "Biology", Time = "01:00 PM - 02:00 PM", Teacher = "Dr. D Patel" },
            new Timetable { Id = 5, Day = "Thursday", Subject = "English", Time = "11:00 AM - 12:00 PM", Teacher = "Ms. E Reddy" },
            new Timetable { Id = 6, Day = "Friday", Subject = "Computer Science", Time = "03:00 PM - 04:00 PM", Teacher = "Mr. F Khan" }
        };

        public ActionResult ViewOnly()
        {
            return View(mockimetable);
        }
        public ActionResult AdminView()
        {
            var timetableList = mockimetable.ToList();
            return View(mockimetable);
        }
        public ActionResult Edit()
        {
            var timetableList = mockimetable.ToList();
            return View(mockimetable);
        }

        // POST: Timetable/Save
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(List<Timetable> updatedTimetable)
        {
            if (updatedTimetable == null || !ModelState.IsValid)
            {
                // Reload the edit view with the same data in case of errors
                return View("Edit", updatedTimetable);
            }

            // Replace the old timetable with the updated one
            for (int i = 0; i < mockimetable.Count; i++)
            {
                var updatedItem = updatedTimetable.FirstOrDefault(t => t.Id == mockimetable[i].Id);
                if (updatedItem != null)
                {
                    mockimetable[i].Day = updatedItem.Day;
                    mockimetable[i].Subject = updatedItem.Subject;
                    mockimetable[i].Time = updatedItem.Time;
                    mockimetable[i].Teacher = updatedItem.Teacher;
                }
            }

            TempData["SuccessMessage"] = "Timetable updated successfully!";
            return RedirectToAction("AdminView");
        }

    }
}