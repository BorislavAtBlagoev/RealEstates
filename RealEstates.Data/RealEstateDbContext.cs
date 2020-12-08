namespace RealEstates.Data
{

    using Microsoft.EntityFrameworkCore;

    using RealEstates.Models;
    using Settings;

    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext()
        {
        }

        public RealEstateDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<BuildingType> BuildingTypes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<RealEstateProperty> RealEstateProperties { get; set; }
        public DbSet<RealEstatePropertyTag> RealEstatePropertyTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(ConnectionStringSettings.DEFAULT_CONNECTION);
            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<District>()
                .HasMany(d => d.Properties)
                .WithOne(p => p.District)
                .OnDelete(DeleteBehavior.Restrict);

            model.Entity<RealEstatePropertyTag>()
                .HasKey(x => new { x.RealEstatePropertyId, x.TagId });
        }
    }
}
