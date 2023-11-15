using Airbnb_API.Models.DTO;

namespace Airbnb_API.Data
{
    public static class AirbnbStore
    {
        public static List<AirbnbDTO> airbnbList = new List<AirbnbDTO>
            {
                new AirbnbDTO {Id=1, Name="Pool View", Sqft=100, Occupancy=4},
                new AirbnbDTO {Id=2, Name="Beach View", Sqft=300, Occupancy=3}
            };
    }
}
