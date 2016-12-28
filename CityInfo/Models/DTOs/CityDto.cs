using System.Collections.Generic;

namespace CityInfo.Models.DTOs
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }

        public int NumberOfPointsOfInterest
        {
            get { return PointsOfInterest.Count; }
        }

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}