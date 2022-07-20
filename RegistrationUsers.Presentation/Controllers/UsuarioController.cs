using Microsoft.AspNetCore.Mvc;
using RegistrationUsers.Application.Dto;
using RegistrationUsers.Application.Dto.Validators;
using RegistrationUsers.Application.Interfaces;
using System.Net;

namespace RegistrationUsers.Presentation.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IApplicationServiceUsuario _applicationServiceUsuario;
        private readonly ILogger _logger;
        public UsuarioController(IApplicationServiceUsuario applicationServiceUsuario)
        {
            _applicationServiceUsuario = applicationServiceUsuario;
            
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioDto>), 200)]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _applicationServiceUsuario.GetAll();
            return Ok(usuarios);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _applicationServiceUsuario.GetById(id);
            if(usuario != null)
                return Ok(usuario);

            return NotFound("Usuário não encontrado.");
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(404)]
        [ProducesResponseType(203)]
        public async Task<IActionResult> Post([FromForm] UsuarioDto usuarioDto)
        {
            try
            {
                if(!this.ModelState.IsValid)
                    return BadRequest(this.ModelState.ReturnErrosModel());              

                var usuario = await _applicationServiceUsuario.Add(usuarioDto);
                return Created(nameof(GetById), new { usuario.Id });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("message",ex.Message);
                return BadRequest(this.ModelState.ReturnErrosModel());
            }
        }

        // PUT api/values/5
        [HttpPut]
        [ProducesResponseType(500)]
        [ProducesResponseType(203)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (!this.ModelState.IsValid)
                    return BadRequest(this.ModelState.ReturnErrosModel());

                if (await _applicationServiceUsuario.Update(usuarioDto))
                    return Ok("Usuário Atualizado com sucesso!");

                return NotFound("Usuário não encontrado");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("message", ex.Message);
                return BadRequest(this.ModelState.ReturnErrosModel());
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(203)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                if(await _applicationServiceUsuario.Remove(id))
                    return Ok("Usuário Removido com sucesso!");

                return NotFound("Usuário não encontrado!");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("message", ex.Message);
                return BadRequest(this.ModelState.ReturnErrosModel());
            }

        }
    }
}
