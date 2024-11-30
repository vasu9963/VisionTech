using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class HomeController : Controller
    {
        templatetestEntities1 db = new templatetestEntities1();
        public ActionResult Index()
        {
            var Slider = db.Slidertables.ToList();
            var Category = db.Categorytables.ToList();
            var About = db.Abouttables.ToList();
            var vm = new UserPanelModel()
            {
                slidertables=Slider,
                categorytables=Category,
                abouttables=About
            };
            return View(vm); 
        }

        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult Recipe1()
        {
            return View();
        }
        public ActionResult Recipe2()
        {
            return View();
        }
        public ActionResult Recipe3()
        {
            return View();
        }
        public ActionResult Recipevideo()
        {
            var RecipeVideo = db.Recipevideotables.ToList();
            var vm = new UserPanelModel()
            { 
                recipevideotables=RecipeVideo
            };
            return View(vm);
        }
        public ActionResult Recipedetail1()
        {
            return View();
        }
        public ActionResult Recipedetail2()
        {
            return View();
        }
        public ActionResult Category()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Blogsingle()
        {
            return View();
        }
        public ActionResult Notfound404()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult About()
        {
            var About = db.Abouttables.ToList();
            var vm = new UserPanelModel()
            { abouttables=About
            };

            return View(vm);
        }
        public ActionResult Addrecipe()
        {
            return View();
        }
        public ActionResult AuthorDetails()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}