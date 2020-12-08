
namespace RealEstates.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RealEstatePropertyTag> Tags { get; set; }
            = new HashSet<RealEstatePropertyTag>();
    }
}
