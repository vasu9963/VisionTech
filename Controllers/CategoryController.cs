using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class CategoryController : Controller
    {
        templatetestEntities1 db = new templatetestEntities1();
        public ActionResult GetCategoryRecords()
        {
            var v = db.Categorytables.ToList();
            return View(v);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Categorytable ab)
        {
            if (ModelState.IsValid)
            {
                var uploadedFile = Request.Files["image"]; // Access the uploaded file by its name in the form

                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {

                    // Generate a unique file name
                    var fileName = Path.GetFileNameWithoutExtension(uploadedFile.FileName);
                    var extension = Path.GetExtension(uploadedFile.FileName);
                    var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";

                    // Set the file path to save the image
                    var filePath = Path.Combine(Server.MapPath("~/ImagesFolder"), uniqueFileName);

                    // Save the image file to the server
                    uploadedFile.SaveAs(filePath);

                    // Save the image path in the model
                    ab.Image = filePath;


                }

                var vm = new Categorytable()
                {
                    Title = ab.Title,
                    Description = ab.Description,
                    Image = ab.Image
                };

                
                db.Categorytables.Add(vm);
                db.SaveChanges();
                return RedirectToAction("GetCategoryRecords");
            }
            return View(ab);
        }
        [HttpGet]
        public ActionResult EditCategory(int ID)
        {
            var v = db.Categorytables.Find(ID);
            return View(v);
        }
        [HttpPost]
        public ActionResult EditCategory(Categorytable ab)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the existing record from the database
                var existingSlider = db.Categorytables.Find(ab.CategoryID);
                if (existingSlider == null)
                {
                    return HttpNotFound(); // Return 404 if the slider is not found
                }

                // Update text fields
                existingSlider.Title = ab.Title;
                existingSlider.Description = ab.Description;

                // Check for a new image file
                var uploadedFile = Request.Files["image"]; // Access the uploaded file by its name in the form
                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {

                    // Generate a unique file name
                    var fileName = Path.GetFileNameWithoutExtension(uploadedFile.FileName);
                    var extension = Path.GetExtension(uploadedFile.FileName);
                    var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";

                    // Set the file path to save the image
                    var filePath = Path.Combine(Server.MapPath("~/ImagesFolder"), uniqueFileName);

                    // Save the image file to the server
                    uploadedFile.SaveAs(filePath);

                    // Update the image path in the model
                    existingSlider.Image = uniqueFileName;

                }

                // Save changes to the database
                db.SaveChanges();
                return RedirectToAction("GetCategoryRecords"); // Redirect to the slider list page
            }
            return View(ab);
        }
        public ActionResult DeleteCategory(int ID)
        {
            var v = db.Categorytables.Find(ID);
            if(v!=null)
            {
                db.Categorytables.Remove(v);
                db.SaveChanges();
                return RedirectToAction("GetCategoryRecords") ; 
            }
            return View();
        }
    }
}