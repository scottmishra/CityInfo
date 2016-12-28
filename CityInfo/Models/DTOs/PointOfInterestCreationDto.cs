using System.ComponentModel.DataAnnotations;

namespace CityInfo.Models.DTOs
{
    /// <summary>
    /// PointOfInterest DTO Model that is used for POST methods, this
    /// was the client doesn't have to deal with Id creation, and the server can handle that
    /// </summary>
    public class PointOfInterestCreationDto
    {
        [Required,MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Description { get; set; }
    }
}