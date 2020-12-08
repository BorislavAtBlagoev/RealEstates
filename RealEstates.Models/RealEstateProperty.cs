
namespace RealEstates.Models
{

    using System;
    using System.Collections.Generic;

    public class RealEstateProperty
    {
        public Guid Id { get; set; }
        public int Size { get; set; }
        public int? Floor { get; set; }
        public int? TotalNumberOfFloors { get; set; }
        public int? Year { get; set; }
        public decimal Price { get; set; }
        public Guid DistrictId { get; set; }
        public virtual District District { get; set; }
        public Guid PropertyTypeId { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public Guid BuildingTypeId { get; set; }
        public virtual BuildingType BuildingType { get; set; }
        public virtual ICollection<RealEstatePropertyTag> Tags { get; set; }
            = new HashSet<RealEstatePropertyTag>();
    }
}
