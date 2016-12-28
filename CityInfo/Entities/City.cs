using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.Entities
{
    /// <summary>
    /// Database related entities
    /// </summary>
    public class City : BaseEntity
    {
       
        public ICollection<PointOfInterest> PointsOfInterest { get; set; }
            = new List<PointOfInterest>();
    }
}