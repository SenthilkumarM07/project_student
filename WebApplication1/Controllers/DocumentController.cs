using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DocumentController : Controller
    {
        // GET: StudentPage
        //private static List<DocumentModel> Documents = new List<DocumentModel>();

        // GET: Document (For Students to view the available documents)
        public ActionResult AdminIndex()
        {
            Class1 context = new Class1();
            var documents = context.Documents.ToList(); // Get all documents
            return View(documents);
        }
        public ActionResult Index()
        {
            Class1 context = new Class1();
            var documents = context.Documents.ToList(); // Get all documents
            return View(documents);
        }
        // GET: Document/Upload
        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        // POST: Document/Upload
        public ActionResult Upload(DocumentModel model, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                Class1 context = new Class1();
                // Generate file path
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Server.MapPath("~/Uploads"), fileName);

                // Save the file to the server
                file.SaveAs(filePath);

                // Set model properties
                model.FileName = fileName;
                model.FilePath = filePath;

                // Optionally, save the document information to the database
                context.Documents.Add(model);
                context.SaveChanges();

                // Redirect to another action or return a success message
                return RedirectToAction("Index"); // Change as per your requirement
            }

            // If no file is uploaded, show an error
            ModelState.AddModelError("", "Please select a file to upload.");
            return View(model); // Re-render the form with the error message
        }

         
        
        public ActionResult Download(int id)
        {
            Class1 context = new Class1();
            var document = context.Documents.FirstOrDefault(d => d.DocumentId == id);
            if (document == null)
            {
                return HttpNotFound();
            }
            var fileBytes = System.IO.File.ReadAllBytes(document.FilePath);
            var fileName = document.FileName;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        Class1 context = new Class1(); // Database context

        // GET: Document/Delete/{id}
        public ActionResult Delete(int id)
        {
            // Find the document by ID
            var document = context.Documents.SingleOrDefault(d => d.DocumentId == id);
            if (document == null)
            {
                return HttpNotFound("Document not found.");
            }

            return View(document); // Display the delete confirmation view
        }

        // POST: Document/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            // Find the document by ID
            var document = context.Documents.SingleOrDefault(d => d.DocumentId == id);
            if (document == null)
            {
                return HttpNotFound("Document not found.");
            }

            // Delete the file from the server
            if (System.IO.File.Exists(document.FilePath))
            {
                System.IO.File.Delete(document.FilePath);
            }

            // Remove the record from the database
            context.Documents.Remove(document);
            context.SaveChanges();

            // Redirect to the list of documents
            return RedirectToAction("AdminIndex");
        }

    }
}