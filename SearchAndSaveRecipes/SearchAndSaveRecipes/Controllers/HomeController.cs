using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchAndSaveRecipes.Models;
using System.Data.Entity.Migrations;

namespace SearchAndSaveRecipes.Controllers
{
    public class HomeController : Controller
    {

        RecipePuppyEntities db = new RecipePuppyEntities();


        public ActionResult Index()
        {
            return View();
        }

        //Method runs when the user hits the "Search" in the site ribbon or when hitting "Next Page"
        public ActionResult DisplayRecipes()
        {
            Search search = (Search) Session["Search"];
            search.Page++;
            List<Recipe> recipes = RecipeAPIDAL.APICall(search.Ingredients, search.Title, search.Page.ToString());
            return View(recipes);
        }

        //Method runs when the user enters a new ingredient and or title in the search view
        [HttpPost]
        public ActionResult DisplayRecipes(string ingredients, string title)
        {
            Search search = new Search();
            search.Title = title;
            search.Ingredients = ingredients;
            search.Page = 1;
            Session["Search"] = search;
        
            List<Recipe> recipes = RecipeAPIDAL.APICall(search.Ingredients, search.Title, search.Page.ToString());
            return View(recipes);
        }

        public ActionResult AddFavorite(string itemTitle, string itemRecipeURL, string itemIngredients, string itemImageURL)
        {
            Recipe r = new Recipe();
            r.Title = itemTitle;
            r.Ingredients = itemIngredients;
            r.ImageURL = itemImageURL;
            r.RecipeURL = itemRecipeURL;

            db.Recipes.AddOrUpdate(r);
            db.SaveChanges();

            return RedirectToAction("DisplayFavorites", "Recipes" );
        }
    }    
}