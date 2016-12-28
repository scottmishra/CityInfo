using System.Collections.Generic;
using System.Linq;
using CityInfo.Entities;

namespace CityInfo.DatabaseContexts
{
    public static class CityInfoContextExtensions
    {
        public static void EnsreSeedDataForContext(this CityInfoContext context)
        {
            var Cities = new List<City>
            {
                new City
                {
                    Name = "Antwerp",
                    Description = "Famous for having an incompete cathedral",
                    PointsOfInterest = new List<PointOfInterest>
                    {
                        new PointOfInterest
                        {
                            Name = "Cathedral",
                            Description = "Half finished cathedral"
                        }
                    }
                },
                new City
                {
                    Name = "New York City",
                    Description = "The city that never sleeps",
                    PointsOfInterest = new List<PointOfInterest>
                    {
                        new PointOfInterest
                        {
                            Name = "Empire State Building",
                            Description = "1-time largest building in the world"
                        }
                    }
                },
                new City
                {
                    Name = "Paris",
                    Description = "City of lights",
                    PointsOfInterest = new List<PointOfInterest>
                    {
                        new PointOfInterest
                        {
                            Name = "Eiffel Tower",
                            Description = "Shining beacon of Paris"
                        }
                    }
                }
            };
            if (context.Cities.Where(c => c.Name.Equals("Paris")).ToList().Count < 1)
            {
                context.Cities.AddRange(Cities);
                context.SaveChanges();
            }

        }
    }
}