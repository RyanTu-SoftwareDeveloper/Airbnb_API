using Airbnb_API.Data;
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
            return AirbnbStore.AirbnbList;
        }
    }
}
