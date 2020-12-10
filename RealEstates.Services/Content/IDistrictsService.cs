namespace RealEstates.Services.Content
{
    using System.Collections.Generic;

    using RealEstates.Services.Models;

    public interface IDistrictsService
    {
        IEnumerable<DistrictViewModel> GetTopDistrictsByAvaragePrice(int count = 10);
        IEnumerable<DistrictViewModel> GetTopDistrictsByProperties(int count);
    }
}
