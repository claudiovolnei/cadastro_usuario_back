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
        public UsuarioController(IApplicationServiceUsuario applicationServiceUsuario)
        {
            _applicationServiceUsuario = applicationServiceUsuario; 
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceUsuario.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceUsuario.GetById(id));
        }

        // POST api/values
        [HttpPost]
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

                throw ex;
            }


        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return NotFound();

                _applicationServiceUsuario.Update(usuarioDto);
                return Ok("Usuário Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return NotFound();

                _applicationServiceUsuario.Remove(usuarioDto);
                return Ok("Usuário Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
