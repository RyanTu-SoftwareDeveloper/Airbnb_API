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
            return Ok(AirbnbStore.airbnbList);
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
            var Airbnb = AirbnbStore.airbnbList.FirstOrDefault(u => u.Id == id);
            if (Airbnb == null)
            {
                return NotFound();
            }
            return Ok(Airbnb);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AirbnbDTO> CreateAirbnb([FromBody]AirbnbDTO airbnbDTO)
        {
            if(airbnbDTO == null)
            {
                return BadRequest(airbnbDTO);
            }
            if(airbnbDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            airbnbDTO.Id = AirbnbStore.airbnbList.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
            AirbnbStore.airbnbList.Add(airbnbDTO);

            return Ok(airbnbDTO);
        }
    }
}





