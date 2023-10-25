using Airbnb_API.Models.DTO;

namespace Airbnb_API.Data
{
    public static class AirbnbStore
    {
        public static List<AirbnbDTO> AirbnbList = new List<AirbnbDTO>
            {
                new AirbnbDTO {Id=1, Name="Pool View"},
                new AirbnbDTO {Id=2, Name="Beach View"}
            };
    }
}
