
namespace RealEstates.Models
{

    using System;

    public class RealEstateProperty
    {
        public Guid Id { get; set; }
        public int Size { get; set; }
        public int Floor { get; set; }
        public int TotalNumberOfFloors { get; set; }
    }
}
