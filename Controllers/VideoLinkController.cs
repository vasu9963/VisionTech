﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class VideoLinkController : Controller
    {
        templatetestEntities1 db = new templatetestEntities1();
        // GET: VideoLink
        public ActionResult GetVideoLink()
        {
            var v = db.Recipevideotables.ToList();
            return View(v);
        }
        [HttpGet]
        public ActionResult AddVideoLink()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVideoLink(Recipevideotable ab)
        {
            if (ModelState.IsValid)
            {
                var uploadedFile = Request.Files["Image"]; // Access the uploaded file by its name in the form

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

                var vm = new Recipevideotable()
                {
                    Heading = ab.Heading,
                    VideoLink = ab.VideoLink,
                    Image = ab.Image
                };


                db.Recipevideotables.Add(vm);
                db.SaveChanges();
                return RedirectToAction("GetVideoLink");
            }
            return View(ab);
        }
        [HttpGet]
        public ActionResult EditVideoLInk(int ID)
        {
            var v = db.Recipevideotables.Find(ID);
            return View(v);
        }
        [HttpPost]
        public ActionResult EditVideoLink(Recipevideotable ab)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the existing record from the database
                var v = db.Recipevideotables.Find(ab.RecipevideoID);
                if (v == null)
                {
                    return HttpNotFound(); // Return 404 if the slider is not found
                }

                // Update text fields
                v.Heading = ab.Heading;
                v.VideoLink = ab.VideoLink;

                // Check for a new image file
                var uploadedFile = Request.Files["Image"]; // Access the uploaded file by its name in the form
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
                    v.Image = uniqueFileName;

                }

                // Save changes to the database
                db.SaveChanges();
                return RedirectToAction("GetVideoLink"); // Redirect to the slider list page
            }
            return View(ab);
        }

        public ActionResult DeleteVideoLink(int ID)
        {
            var v = db.Recipevideotables.Find(ID);
            if(v!=null)
            {
                db.Recipevideotables.Remove(v);
                db.SaveChanges();
                return RedirectToAction("GetVideoLink");
            }
            return View(v);
        }
    }
}