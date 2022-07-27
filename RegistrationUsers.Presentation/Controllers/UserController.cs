using Microsoft.AspNetCore.Mvc;
using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Application.Dto.Validators;
using RegistrationUsers.Application.Interfaces;
using System.Net;

namespace RegistrationUsers.Presentation.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IApplicationServiceUser _applicationServiceUser;
        private readonly ILogger _logger;
        public UserController(IApplicationServiceUser applicationServiceUser)
        {
            _applicationServiceUser = applicationServiceUser;
            
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), 200)]
        public async Task<IActionResult> Get()
        {
            var users = await _applicationServiceUser.GetAllAsync();
            return Ok(users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _applicationServiceUser.GetById(id);
            if(user != null)
                return Ok(user);

            return NotFound("Usuário não encontrado.");
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(404)]
        [ProducesResponseType(203)]
        public async Task<IActionResult> Post([FromForm] UserDto userDto)
        {
            try
            {
                if(!this.ModelState.IsValid)
                    return BadRequest(this.ModelState.ReturnErrosModel());              

                var user = await _applicationServiceUser.Add(userDto);
                return Created(nameof(GetById), new { user.Id });
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
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromBody] UserDto userDto)
        {
            try
            {
                if (!this.ModelState.IsValid)
                    return BadRequest(this.ModelState.ReturnErrosModel());

                bool response = await _applicationServiceUser.Update(userDto);

                if (response)
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
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                bool response = await _applicationServiceUser.Remove(id);

                if (response)
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
