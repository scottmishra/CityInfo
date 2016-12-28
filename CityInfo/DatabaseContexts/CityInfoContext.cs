using CityInfo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.DatabaseContexts
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions options) : base(options)
        {
            //This will execute migrations if they havent been
            //applied
            Database.Migrate();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointOfInterests { get; set; }
    }
}