using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.Entities
{
    public class PointOfInterest : BaseEntity
    {
        //City is the navigation property to parent entity
        [ForeignKey("CityId")] //The City, CityId object nameing is convention, the annotation is explicit
        public City City { get; set; }
        public int CityId { get; set; }
    }
}