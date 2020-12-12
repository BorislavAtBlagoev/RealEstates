using RealEstates.Data;
using RealEstates.Services;
using RealEstates.Services.Content;

using System;
using System.Linq;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new RealEstateDbContext();
            IDistrictsService districtsService = new DistrictsService(db);
            var a = districtsService.GetTopDistrictsByAvaragePrice();

            ;
        }
    }
}
