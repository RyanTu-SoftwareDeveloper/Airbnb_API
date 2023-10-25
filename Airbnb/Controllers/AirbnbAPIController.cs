using Airbnb_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb_API.Controllers
{
    [Route("api/AirbnbAPI")]
    [ApiController]
    public class AirbnbAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Airbnb> GetAirbnbs()
        {
            return new List<Airbnb>
            {
                new Airbnb {Id=1, Name="Pool View"},
                new Airbnb {Id=2, Name="Beach View"}
            };
        }
    }
}
