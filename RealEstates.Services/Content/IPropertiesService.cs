namespace RealEstates.Services.Content
{
    using System;
    using System.Collections.Generic;

    using RealEstates.Services.Models;

    public interface IPropertiesService
    {
        void Create(string district, string buildingType, string propertyType, int size, int? floor, int? totalNumberOfFloors, decimal price, int? year);
        void UpdateTags(Guid propertyId);
        IEnumerable<PropertyViewModel> SearchByYearAndSize(int minYear, int maxYear, int minSize, int maxSize);
        IEnumerable<PropertyViewModel> SearchByPrice(decimal minPrice, decimal maxPrice);

    }
}
