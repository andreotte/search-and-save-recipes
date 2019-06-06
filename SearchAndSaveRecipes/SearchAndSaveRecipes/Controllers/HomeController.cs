using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchAndSaveRecipes.Models;

namespace SearchAndSaveRecipes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetRecipesFromAPI(string ingredients, string title)
        {
            RecipeAPIDAL.APICall(ingredients, title);
            return RedirectToAction("DisplayRecipes");
        }

        public ActionResult DisplayRecipes()
        {
            return View();
        }
    }
}