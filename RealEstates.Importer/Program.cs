namespace RealEstates.Importer
{
    using System.IO;

    using Newtonsoft.Json;

    using RealEstates.Data;
    using RealEstates.Services;
    using RealEstates.Services.Content;
    using RealEstates.Importer.Models;
    public class Program
    {
        public static void Main()
        {
            var db = new RealEstateDbContext();
            IPropertiesService propertyService = new PropertiesService(db);

            var json = File.ReadAllText("RealEstates.json");

            var properties = JsonConvert.DeserializeObject<PropertyImportModel[]>(json);

            foreach (var property in properties)
            {
                try
                {
                    propertyService.Create(
                    property.District,
                    property.BuildingType,
                    property.PropertyType,
                    property.Size,
                    property.Floor,
                    property.TotalFloors,
                    property.Price,
                    property.Year);
                }
                catch
                {
                }
            }
        }
    }
}
