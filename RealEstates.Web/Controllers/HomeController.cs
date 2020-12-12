using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstates.Services.Content;
using RealEstates.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstates.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistrictsService districtsService;

        public HomeController(IDistrictsService districtsService)
        {
            this.districtsService = districtsService;
        }

        public IActionResult Index()
        {
            var districts = this.districtsService.GetTopDistrictsByAvaragePrice(20);
            return View(districts);
        }

        public IActionResult Privacy()
        {
            return Redirect("https://softuni.bg/trainings/2843/entity-framework-core-june-2020#lesson-15532");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
