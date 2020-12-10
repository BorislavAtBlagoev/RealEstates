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
            IPropertiesService propertyService = new PropertiesService(db);
            IDistrictsService districtsService = new DistrictsService(db);

            //propertyService.Create("Левски-Г", "Тухла", "3-стаен", 50, 1, 1, 20000.50m, 1940);
            var districts = districtsService.GetTopDistrictsByAvaragePrice(10);
            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} {district.AvaragePrice} {district.MinPrice} {district.MaxPrice} {district.PropertiesCount}");
            }
           
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

        }
    }
}
