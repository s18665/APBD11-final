using APBD11.Entities;
using APBD11.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD11.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorsController : ControllerBase
    {
        private readonly MsSqlService _service;

        public DoctorsController(MsSqlService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IActionResult GetDoctor(int id)
        {
            var toReturn = _service.GetDoctor(id);
            if (toReturn == null)
            {
                return NotFound();
            }

            return Ok(toReturn);
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor request)
        {
            var toReturn = _service.AddDoctor(request);
            if (toReturn == null)
            {
                return BadRequest();
            }

            return Ok(toReturn);
        }

        [HttpPost("update")]
        public IActionResult UpdateDoctor(Doctor request)
        {
            var toReturn = _service.UpdateDoctor(request);
            if (toReturn == null)
            {
                return NotFound();
            }

            return Ok(toReturn);
        }
        
        [HttpDelete]
        public IActionResult DeleteDoctor(int id)
        {
            if (_service.DeleteDoctor(id))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}