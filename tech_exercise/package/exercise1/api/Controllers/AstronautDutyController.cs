
using Microsoft.AspNetCore.Mvc;
using StargateAPI.Data;
using StargateAPI.Services;
using System.Net;

namespace StargateAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AstronautDutyController : ControllerBase
    {
        private readonly IAstroDutyService _service;
        public AstronautDutyController(IAstroDutyService service)
        {
            _service = service;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetAstronautDutiesByName(string name)
        {
            if (name == null || name == "" || name.Length < 3)
			{
				return BadRequest();
			}

			var result = await _service.GetByName(name);
            return Ok(result);//TODO
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAstronautDuty([FromBody] AstronautDuty astronautDuty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddDuty(astronautDuty);
			if (result)
            {
				return Created();
            }

            return Ok("Astronaut Duty Failed to Create");
		}
    }
}