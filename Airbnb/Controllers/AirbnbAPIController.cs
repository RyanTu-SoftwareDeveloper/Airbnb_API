using Airbnb_API.Models;
using Airbnb_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb_API.Controllers
{
    [Route("api/AirbnbAPI")]
    [ApiController]
    public class AirbnbAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<AirbnbDTO> GetAirbnbs()
        {
            return new List<AirbnbDTO>
            {
                new AirbnbDTO {Id=1, Name="Pool View"},
                new AirbnbDTO {Id=2, Name="Beach View"}
            };
        }
    }
}
