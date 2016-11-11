using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartV1.Models;

namespace ShoppingCartV1.Controllers
{
    [HandleError]
    public partial class HomeController : Controller
    {
        // Text for Site Heading
        string siteHeading = "The Fun Cake Store";

        // Text for Order View Heading
        string orderHeading = "Cake Orders";

        // Text for View Heading for each Tab
        string[] tabHeadings = { "Home", "Single Layer Cake","Double Layer Cake", "Triple Layer Cake",
                                                 "About" };

        // View method name for each Tab
        string[] tabViews = { "Index", "Tab1Orders", "Tab2Orders", "Tab3Orders",
                                                 "About" };

        // View label displayed on each Tab
        string[] tabLabels = { "Home", "1-Layer","2-Layer","3-Layer",
                                                 "About" };

        // Action Method for Home page View
        public ActionResult Index()
        {
            Session["PageHeading"] = siteHeading;
            ViewBag.Title = "Welcome to the Fun Cake Store!";
            ViewBag.Message = "<img src = \"/Images/Logo.jpg\">";
            ViewBag.Message += "<br /> This is the Cake Store of your Dreams!";
            return View();
        }

        // Action Method for About page View
        public ActionResult About()
        {
            Session["PageHeading"] = siteHeading;
            ViewBag.Title = "About " + siteHeading;
            ViewBag.Message = "Your app description page.";
            return View();
        }

        // Action Method for First Product View
        public ActionResult Tab1Orders()
        {
            int tabNum = 1;
            Session["PageHeading"] = orderHeading;
            Session["ProductType"] = tabViews[tabNum];
            ViewBag.Message = Session["Message"] = tabHeadings[tabNum] + " Orders:";
            return View(LoadViewTableData(Session["ProductType"].ToString(), tabNum));
        }

        // Action Method for First Product View
        [HttpPost]
        public ActionResult Tab1Orders(string button, FormCollection collection)
        {
            int tabNum = 1;
            string pType = Session["ProductType"].ToString();
            int amount = Int32.Parse(Session[pType + "ItemAmount"].ToString());

            LoadSubmission(pType, amount, collection);

            for (int i = 1; i <= amount; i++)
            {
                int value;
                if (!Int32.TryParse(collection[i - 1], out value) || value < 0)
                {
                    ViewBag.Message = "<div style=\"color:#800\">" +
                                       "Error: Invalid entry in Item #" + i +
                                        "</div><br />" + Session["Message"].ToString();
                    return View(pType, LoadViewTableData(pType, tabNum));
                }
            }

            if (button == "Save And Go To Checkout")
            {
                return RedirectToAction("CheckOut");
            }
            else
            {
                // This is the View for the next product page
                return RedirectToAction(tabViews[tabNum + 1]);
            }
        }

        // Action Method for First Product View
        public ActionResult Tab2Orders()
        {
            int tabNum = 2;
            Session["PageHeading"] = orderHeading;
            Session["ProductType"] = tabViews[tabNum];
            ViewBag.Message = Session["Message"] = tabHeadings[tabNum] + " Orders:";
            return View(LoadViewTableData(Session["ProductType"].ToString(), tabNum));
        }

        // Action Method for First Product View
        [HttpPost]
        public ActionResult Tab2Orders(string button, FormCollection collection)
        {
            int tabNum = 2;
            string pType = Session["ProductType"].ToString();
            int amount = Int32.Parse(Session[pType + "ItemAmount"].ToString());

            LoadSubmission(pType, amount, collection);

            for (int i = 1; i <= amount; i++)
            {
                int value;
                if (!Int32.TryParse(collection[i - 1], out value) || value < 0)
                {
                    ViewBag.Message = "<div style=\"color:#800\">" +
                                       "Error: Invalid entry in Item #" + i +
                                        "</div><br />" + Session["Message"].ToString();
                    return View(pType, LoadViewTableData(pType, tabNum));
                }
            }

            if (button == "Save And Go To Checkout")
            {
                return RedirectToAction("CheckOut");
            }
            else
            {
                // This is the View for the next product page
                return RedirectToAction(tabViews[tabNum + 1]);
            }
        }

        // Action Method for First Product View
        public ActionResult Tab3Orders()
        {
            int tabNum = 3;
            Session["PageHeading"] = orderHeading;
            Session["ProductType"] = tabViews[tabNum];
            ViewBag.Message = Session["Message"] = tabHeadings[tabNum] + " Orders:";
            return View(LoadViewTableData(Session["ProductType"].ToString(), tabNum));
        }

        // Action Method for First Product View
        [HttpPost]
        public ActionResult Tab3Orders(string button, FormCollection collection)
        {
            int tabNum = 3;
            string pType = Session["ProductType"].ToString();
            int amount = Int32.Parse(Session[pType + "ItemAmount"].ToString());

            LoadSubmission(pType, amount, collection);

            for (int i = 1; i <= amount; i++)
            {
                int value;
                if (!Int32.TryParse(collection[i - 1], out value) || value < 0)
                {
                    ViewBag.Message = "<div style=\"color:#800\">" +
                                       "Error: Invalid entry in Item #" + i +
                                        "</div><br />" + Session["Message"].ToString();
                    return View(pType, LoadViewTableData(pType, tabNum));
                }
            }

            if (button == "Save And Go To Checkout")
            {
                return RedirectToAction("CheckOut");
            }
            else
            {
                // This is the View for the next product page
                return RedirectToAction(tabViews[tabNum + 1]);
            }
        }
    }
}
