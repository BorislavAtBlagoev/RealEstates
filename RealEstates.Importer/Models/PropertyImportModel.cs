
namespace RealEstates.Importer.Models
{
    using Newtonsoft.Json;

    public class PropertyImportModel
    {
        public string District { get; set; }
        public string BuildingType { get; set; }

        [JsonProperty("Type")]
        public string PropertyType { get; set; }
        public int Size { get; set; }
        public int Floor { get; set; }
        public int TotalFloors { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
    }
}
