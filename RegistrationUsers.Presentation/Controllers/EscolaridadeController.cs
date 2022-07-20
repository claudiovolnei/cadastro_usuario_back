using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Application.Interfaces;

namespace RegistrationUsers.Presentation.Controllers
{
    [Route("[controller]")]
    public class EscolaridadeController : ControllerBase
    {
        private readonly IApplicationServiceEscolaridade _applicationServiceEscolaridade;
        public EscolaridadeController(IApplicationServiceEscolaridade applicationServiceEscolaridade)
        {
            _applicationServiceEscolaridade = applicationServiceEscolaridade; 
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<HistoricoEscolarDto>),200)]        
        public async Task<IActionResult> Get()
        {
            var escolaridades = await _applicationServiceEscolaridade.GetAll();
            return Ok(escolaridades);
        }
    }
}
