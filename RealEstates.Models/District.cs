﻿
namespace RealEstates.Models
{

    using System;
    using System.Collections.Generic;

    public class District
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<RealEstateProperty> Properties { get; set; } 
            = new HashSet<RealEstateProperty>();
    }
}
