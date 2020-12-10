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

    public class PropertiesService : IPropertiesService
    {
        private readonly RealEstateDbContext db;

        public PropertiesService(RealEstateDbContext db)
        {
            this.db = db;
        }

        public void Create(string district, string buildingType, string propertyType, int size, int? floor, int? totalNumberOfFloors, decimal price, int? year)
        {
            if (district == null)
            {
                throw new ArgumentNullException(nameof(district));
            }

            var property = new RealEstateProperty
            {
                Size = size,
                Price = price,
                Year = year < 1800 ? null : year,
                Floor = floor <= 0 ? null : floor,
                TotalNumberOfFloors = totalNumberOfFloors <= 0 ? null : totalNumberOfFloors
            };

            //District
            var districtEntity = this.db.Districts
                .FirstOrDefault(x => x.Name.Trim() == district.Trim());

            if (districtEntity == null)
            {
                districtEntity = new District
                {
                    Name = district,
                };
            }

            property.District = districtEntity;

            //BuildingType
            var buildingTypeEntity = this.db.BuildingTypes
                .FirstOrDefault(x => x.Name.Trim() == buildingType.Trim());

            if (buildingTypeEntity == null)
            {
                buildingTypeEntity = new BuildingType
                {
                    Name = buildingType
                };
            }

            property.BuildingType = buildingTypeEntity;

            //PropertyType
            var propertyTypeEntity = this.db.PropertyTypes
                .FirstOrDefault(x => x.Name.Trim() == propertyType.Trim());

            if (propertyTypeEntity == null)
            {
                propertyTypeEntity = new PropertyType
                {
                    Name = propertyType
                };
            }

            property.PropertyType = propertyTypeEntity;

            this.db.RealEstateProperties.Add(property);
            this.db.SaveChanges();

            this.UpdateTags(property.Id);

            this.db.SaveChanges();
        }
        public void UpdateTags(Guid propertyId)
        {
            var property = this.db.RealEstateProperties
                .Find(propertyId);

            property.Tags.Clear();

            if (property.Year.HasValue && property.Year < 1990)
            {
                property.Tags.Add(new RealEstatePropertyTag { Tag = this.GetOrCreateTag("Old building!") });
            }

            if (property.Size < 60)
            {
                property.Tags.Add(new RealEstatePropertyTag { Tag = this.GetOrCreateTag("Very small property!") });
            }
        }
        public IEnumerable<PropertyViewModel> SearchByYearAndSize(int minYear, int maxYear, int minSize, int maxSize)
        {
            return db.RealEstateProperties
                .Where(x => (x.Year >= minYear && x.Year <= maxYear) && (x.Size >= minSize && x.Size <= maxSize))
                .Select(MapPropertyViewModel())
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Size)
                .ToList();
        }
        public IEnumerable<PropertyViewModel> SearchByPrice(decimal minPrice, decimal maxPrice)
        {
            return this.db.RealEstateProperties
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .Select(MapPropertyViewModel())
                .OrderBy(x => x.Price)
                .ToList();
        }

        private Tag GetOrCreateTag(string tag)
        {
            var tagEntity = this.db.Tags
                .FirstOrDefault(x => x.Name == tag);

            if (tagEntity == null)
            {
                tagEntity = new Tag { Name = tag };
            }

            return tagEntity;
        }
        private static Expression<Func<RealEstateProperty, PropertyViewModel>> MapPropertyViewModel()
        {
            return x => new PropertyViewModel
            {
                District = x.District.Name,
                BuildingType = x.BuildingType.Name,
                PropertyType = x.PropertyType.Name,
                Floor = $"{x.Floor ?? 0}/{x.TotalNumberOfFloors ?? 0}",
                Size = x.Size,
                Price = x.Price,
                Year = x.Year
            };
        }
    }
}
