using System.ComponentModel.DataAnnotations;

namespace CityInfo.Models.DTOs
{
    public class PointOfInterestUpdateDto
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}