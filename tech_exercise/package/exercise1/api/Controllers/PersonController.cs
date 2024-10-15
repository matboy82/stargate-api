
using Microsoft.AspNetCore.Mvc;
using StargateAPI.Data;
using StargateAPI.Services;

namespace StargateAPI.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetPeople()
        {
            var result = await _personService.GetAllPeople();

            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetPersonByName(string name)
        {
            if (name == null || name == "" || name.Length < 3)
            {
                return BadRequest("Name does not fit expected format");
            }

			var result = await _personService.GetPerson(name);

			return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreatePerson([FromBody] Person person)
        {
            if (ModelState.IsValid)
			{
				var result = await _personService.AddPerson(person);
                if (result)
                {
					return Created();
				}
                else
                {
                    return Ok("Failed to Create Person");
                }
				
			}
			else
			{
				return BadRequest(ModelState);
			}

        }

		[HttpPut("")]
		public async Task<IActionResult> UpdatePerson([FromBody] Person person)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);

			}

			var result = await _personService.UpdatePerson(person);
			if (result)
			{
				return Ok();
			}
			else
			{
				return Ok("Failed to Update Person");
			}

		}
	}
}