using Microsoft.AspNetCore.Mvc;
using RegistrationUsers.Application.Dto;
using RegistrationUsers.Application.Interfaces;

namespace RegistrationUsers.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IApplicationServiceUsuario _applicationServiceUsuario;
        private readonly ILogger _logger;
        public UsuarioController(IApplicationServiceUsuario applicationServiceUsuario, ILogger logger)
        {
            _applicationServiceUsuario = applicationServiceUsuario;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UsuarioDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceUsuario.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> Get(int id)
        {
            var usuario = _applicationServiceUsuario.GetById(id);
            if(usuario is null)
                return NotFound("Usuário não encontrado!");
            return Ok(usuario);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return NotFound();

                _applicationServiceUsuario.Add(usuarioDto);
                return Ok("Usuário Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // PUT api/values/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return BadRequest("Usuário inválido!");                               

                if (_applicationServiceUsuario.Update(usuarioDto))
                    return Ok("Usuário Atualizado com sucesso!");

                return BadRequest("Usuário não encontrado");
            }
            catch (Exception)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return NotFound();

                if(_applicationServiceUsuario.Remove(id))
                    return Ok("Usuário Removido com sucesso!");

                return BadRequest("Usuário não encontrado!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }

        }
    }
}
