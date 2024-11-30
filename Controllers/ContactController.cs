using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class ContactController : Controller
    {
        templatetestEntities1 db = new templatetestEntities1();
        // GET: Contact
        public ActionResult ShowContactData()
        {
            var v = db.Contacttables.ToList();
            return View(v);
        }
        [HttpPost]
        public JsonResult Add_Data(Contacttable ab)
        {

            // Create a new instance of Contacttable and populate it
            var vm = new Contacttable()
            {
                Subject = ab.Subject,
                Name = ab.Name,
                Email = ab.Email,
                Message = ab.Message
            };

            // Add the new record to the database and save changes
            db.Contacttables.Add(vm);
          var result =  db.SaveChanges();
           if(result == 1)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            } 

            // Return a success response
            return Json(new { success= false },JsonRequestBehavior.AllowGet);
        }     
    }
}