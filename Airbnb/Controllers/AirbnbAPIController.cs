using Airbnb_API.Data;
using Airbnb_API.Models;
using Airbnb_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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
        [HttpGet("{id:int}", Name = "GetAirbnb")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AirbnbDTO> GetAirbnb(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var airbnb = AirbnbStore.airbnbList.FirstOrDefault(u => u.Id == id);
            if (airbnb == null)
            {
                return NotFound();
            }
            return Ok(airbnb);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AirbnbDTO> CreateAirbnb([FromBody]AirbnbDTO airbnbDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (AirbnbStore.airbnbList.FirstOrDefault(u => u.Name.ToLower() == airbnbDTO.Name.ToLower()) != null) 
            {
                ModelState.AddModelError("CustomError", "Airbnb already Exists!");
                return BadRequest(ModelState);
            }
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

            return CreatedAtRoute("GetAirbnb", new { id = airbnbDTO.Id }, airbnbDTO);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteAirbnb")]
        public IActionResult DeleteAirbnb(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var airbnb = AirbnbStore.airbnbList.FirstOrDefault(u => u.Id == id);
            if (airbnb == null)
            {
                return NotFound();
            }
            AirbnbStore.airbnbList.Remove(airbnb);
            return NoContent();
        }
    }
}





