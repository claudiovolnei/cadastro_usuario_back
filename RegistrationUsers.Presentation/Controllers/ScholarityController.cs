using Microsoft.AspNetCore.Mvc;
using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Application.Interfaces;

namespace RegistrationUsers.Presentation.Controllers
{
    [Route("[controller]")]
    public class ScholarityController : ControllerBase
    {
        private readonly IApplicationServiceScholarity _applicationServiceScholarity;
        public ScholarityController(IApplicationServiceScholarity applicationServiceScholarity)
        {
            _applicationServiceScholarity = applicationServiceScholarity; 
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SchoolRecordsDto>),200)]        
        public async Task<IActionResult> Get()
        {
            var scholarities = await _applicationServiceScholarity.GetAll();
            return Ok(scholarities);
        }
    }
}
