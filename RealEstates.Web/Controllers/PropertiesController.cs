namespace RealEstates.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using RealEstates.Services.Content;
    using RealEstates.Services.Models;
    using RealEstates.Web.Models;
    using System.Collections.Generic;

    public class PropertiesController : Controller
    {
        private readonly IPropertiesService propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
        {
            this.propertiesService = propertiesService;
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(PropertySearchByPriceRequestModel model)
        {
            var properties = this.propertiesService.SearchByPrice(model.MinPrice, model.MaxPrice);

            return View("Get", properties);
        }
    }
}
