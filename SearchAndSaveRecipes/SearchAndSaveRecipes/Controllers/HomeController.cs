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
        public ActionResult DisplayRecipes(string ingredients, string title)
        {
            List<Recipe> recipes = RecipeAPIDAL.APICall(ingredients, title);
            return View(recipes);
        }


    }
}