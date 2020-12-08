namespace RealEstates.Models
{

    using System;

    public class RealEstatePropertyTag
    {
        public Guid RealEstatesPropertyId { get; set; }
        public virtual RealEstateProperty RealEstateProperty { get; set; }
        public Guid TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
