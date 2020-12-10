namespace RealEstates.Services.Models
{
    public class DistrictViewModel
    {
        public string Name { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal AvaragePrice { get; set; }
        public int PropertiesCount { get; set; }
    }
}
