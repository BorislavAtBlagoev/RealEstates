namespace RealEstates.Services
{

    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using RealEstates.Data;
    using RealEstates.Models;
    using RealEstates.Services.Models;
    using RealEstates.Services.Content;


    public class DistrictsService : IDistrictsService
    {
        private readonly RealEstateDbContext db;

        public DistrictsService(RealEstateDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<DistrictViewModel> GetTopDistrictsByAvaragePrice(int count = 10)
        {
            return db.Districts
                .Select(MapToDistrictViewModel())
                .OrderByDescending(x => x.AvaragePrice)
                .Take(count)
                .ToList();
        }

        public IEnumerable<DistrictViewModel> GetTopDistrictsByProperties(int count = 10)
        {
            return this.db.Districts
                .Select(MapToDistrictViewModel())
                .OrderByDescending(x => x.PropertiesCount)
                .Take(count)
                .ToList();
        }

        private static Expression<Func<District, DistrictViewModel>> MapToDistrictViewModel()
        {
            return x => new DistrictViewModel
            {
                Name = x.Name,
                MinPrice = x.Properties.Min(x => x.Price),
                MaxPrice = x.Properties.Max(x => x.Price),
                AvaragePrice = x.Properties.Average(x => x.Price),
                PropertiesCount = x.Properties.Count()
            };
        }

    }
}
