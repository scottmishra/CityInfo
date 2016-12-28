using System.ComponentModel.DataAnnotations;

namespace CityInfo.Models.DTOs
{
    public class CreateCityDto
    {
        [Required,MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Description { get; set; }
    }
}