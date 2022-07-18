using Microsoft.AspNetCore.Mvc;
using RegistrationUsers.Application.Dto;
using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Application.Interfaces;

namespace RegistrationUsers.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EscolaridadeController : ControllerBase
    {
        private readonly IApplicationServiceEscolaridade _applicationServiceEscolaridade;
        public EscolaridadeController(IApplicationServiceEscolaridade applicationServiceEscolaridade)
        {
            _applicationServiceEscolaridade = applicationServiceEscolaridade; 
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EscolaridadeDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<EscolaridadeDto>> Get()
        {
            return Ok(_applicationServiceEscolaridade.GetAll());
        }
    }
}
