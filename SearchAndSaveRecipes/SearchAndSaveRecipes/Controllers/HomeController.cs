﻿using System;
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

        public ActionResult Add()
        {
            return RedirectToAction("~/Recipes/Index");
        }

    }

    
}