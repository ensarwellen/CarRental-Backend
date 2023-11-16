using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rental;

        public RentalsController(IRentalService rental)
        {
            _rental = rental;
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rental.Add(rental);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rental.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getrentdatesbycarid")]
        public IActionResult getRentDatesByCarId(int carId)
        {
            var result = _rental.GetRentDatesByCarId(carId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
