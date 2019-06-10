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

        RecipePuppyEntities1 db = new RecipePuppyEntities1();

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult DisplayRecipes(string ingredients, string title)
        {
            if (Session["page"] != null)
            {
                int pageNumber = (int)Session["page"];
                pageNumber++;
                Session["page"] = pageNumber;
            }
            else
            {
                Session["page"] = 1;
            }

            if (Session["ingredients"] != null)
            {
                ingredients = Session["ingredients"].ToString();
            }
            else
            {
                Session["ingredients"] = ingredients;
            }

            if (Session["title"] != null)
            {
                title = Session["title"].ToString();
            }
            else
            {
                Session["title"] = title;
            }

            string page = Session["page"].ToString();

            List<Recipe> recipes = RecipeAPIDAL.APICall(ingredients, title, page);
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
            Session["OnFavorites"] = "true";

            return RedirectToAction("DisplayFavorites", "Recipes" );

        }


    }    
}