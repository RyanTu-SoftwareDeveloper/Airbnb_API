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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<AirbnbDTO>> GetAirbnbs()
        {
            return Ok(AirbnbStore.AirbnbList);
        }
        [HttpGet("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AirbnbDTO> GetAirbnbs(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var Airbnb = AirbnbStore.AirbnbList.FirstOrDefault(u => u.Id == id);
            if (Airbnb == null)
            {
                return NotFound();
            }
            return Ok(Airbnb);
        }
    }
}





