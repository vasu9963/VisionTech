using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class SliderController : Controller
    {
        templatetestEntities1 db = new templatetestEntities1();
        // GET: Slider
        public ActionResult Getsliders()
        {
            var v = db.Slidertables.ToList();
            return View(v);
        }
        [HttpGet]
        public ActionResult AddSlider()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult AddSlider(Slidertable model)
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
                        model.Image = filePath;


                }

                var vm = new Slidertable()
                { 
                    Title=model.Title,
                    Description=model.Description,
                    Image=model.Image
                };

                // Save the slider data to the database
                db.Slidertables.Add(model);
                db.SaveChanges();
                return RedirectToAction("Getsliders");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult EditSlider(int ID)
        {
            var v = db.Slidertables.Find(ID);

            return View(v);
        }
        [HttpPost]
        public ActionResult EditSlider(Slidertable ab)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the existing record from the database
                var existingSlider = db.Slidertables.Find(ab.SliderID);
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
                return RedirectToAction("Getsliders"); // Redirect to the slider list page
            }
            return View(ab); // Re-render the form if validation fails
            
        }
        public ActionResult DeleteSlider(int ID)
        {
            var v = db.Slidertables.Find(ID);
            if(v!=null)
            {
                db.Slidertables.Remove(v);
                db.SaveChanges();
                return RedirectToAction("Getsliders");
            }
            return View();
        }
    }
}