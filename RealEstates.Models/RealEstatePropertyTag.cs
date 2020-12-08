using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Models
{
    public class RealEstatePropertyTag
    {
        public Guid RealEstatesPropertyId { get; set; }
        public virtual RealEstateProperty RealEstateProperty { get; set; }
        public Guid TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
