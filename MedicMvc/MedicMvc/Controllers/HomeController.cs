﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;

using Google.Apis.Services;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using System.Diagnostics;
using MedicMvc.Helpers;
using MedicMvc.Models;

namespace MedicMvc.Controllers
{
    public class HomeController : Controller
    {
        #region Private Methods

        private void SetActiveTab(string active)
        {
            ViewBag.IndexClass = "";
            ViewBag.CommunicateClass = "";
            ViewBag.MedicineClass = "";
            ViewBag.DischargeClass = "";
            ViewBag.RatingClass = "";
            ViewBag.PainClass = "";
            ViewBag.AboutClass = "";
            ViewBag.ContactClass = "";

            switch (active)
            {
                case "Index":
                    ViewBag.IndexClass = "active";
                    break;
                case "Communicate":
                    ViewBag.CommunicateClass = "active";
                    break;
                case "Medicine":
                    ViewBag.MedicineClass = "active";
                    break;
                case "Discharge":
                    ViewBag.DischargeClass = "active";
                    break;
                case "Rating":
                    ViewBag.RatingClass = "active";
                    break;
                case "Pain":
                    ViewBag.PainClass = "active";
                    break;
                case "About":
                    ViewBag.AboutClass = "active";
                    break;
                case "Contact":
                    ViewBag.ContactClass = "active";
                    break;
                default:
                    break;
            }
        }

        #endregion // Private Methods

        #region Actions

        public ActionResult Index()
        {
            ViewBag.Message = "Home Page.";
            SetActiveTab("Index");

            return View();
        }

        public ActionResult Communicate()
        {
            ViewBag.Message = "Communicate with Doctors and Nurses";
            SetActiveTab("Communicate");

            return View();
        }

        public ActionResult Medicine()
        {
            ViewBag.Message = "Medicine info page.";
            SetActiveTab("Medicine");

            return View();
        }

        public ActionResult Discharge()
        {
            ViewBag.Message = "Discharge informationn page.";
            SetActiveTab("Discharge");

            return View();
        }

        public ActionResult Rating()
        {
            ViewBag.Message = "Hospital Rating page.";
            SetActiveTab("Rating");

            return View();
        }

        public ActionResult Pain()
        {
            ViewBag.Message = "Pain Management page.";
            SetActiveTab("Pain");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About page.";
            SetActiveTab("About");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            SetActiveTab("Contact");

            return View();
        }
        public ActionResult HandleSearch(string searchTextInput)
        {
            Search s = SearchInterface.Querry(searchTextInput);

            Debug.WriteLine(searchTextInput);

            //results = new List<ResultModel>();
            //foreach (Result r in s.Items)
            //{
            //    results.Add(new ResultModel(r));
            //}
            return View("SearchResults", s.Items);
        }

        #endregion // Actions
    }
}
