using System.ComponentModel.DataAnnotations;

namespace Airbnb_API.Models.DTO
{
    public class AirbnbDTO
    {
        

        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Occupancy { get; set; }
        public int Sqft { get; set; }
      
    }
}
