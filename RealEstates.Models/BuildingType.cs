namespace RealEstates.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BuildingType
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<RealEstateProperty> Properties { get; set; } 
            = new HashSet<RealEstateProperty>();
    }
}
