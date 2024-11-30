using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class AdminController : Controller
    {
        templatetestEntities1 db = new templatetestEntities1();
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Adminlogin ab)
        {
            if(ModelState.IsValid)
            {
                if (ab.username=="vasu" && ab.password=="vasu")
                {
                    return RedirectToAction("Index","Dashboard");
                }
            }
            return View(ab);
        }
    }
}