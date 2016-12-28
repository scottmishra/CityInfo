namespace CityInfo.Models.DTOs
{
    /// <summary>
    /// DTO to contain information about a point of interest for a city
    /// </summary>
    public class PointOfInterestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}