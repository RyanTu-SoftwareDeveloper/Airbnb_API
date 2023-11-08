using System.ComponentModel.DataAnnotations;

namespace Airbnb_API.Models.DTO
{
    public class AirbnbDTO
    {
        internal static object airbnbList;

        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
      
    }
}
