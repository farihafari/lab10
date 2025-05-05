using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoapAppNew.Models;
using SoapAppNew.CountryServiceReference;

namespace SoapAppNew.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = new CountryInfoServiceSoapTypeClient();
                string capital = client.CapitalCity(model.CountryISOCode);
                model.CapitalCity = capital;
            }
            return View(model);
        }
    }
}