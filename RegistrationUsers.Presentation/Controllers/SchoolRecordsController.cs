using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Application.Dto.Validators;
using RegistrationUsers.Application.Interfaces;

namespace RegistrationUsers.Presentation.Controllers
{
    [Route("[controller]")]
    public class SchoolRecordsController : Controller
    {
        private readonly IApplicationServiceUser _applicationServiceUser;
        private readonly IApplicationServiceSchoolRecords _applicationServiceSchoolRecords;
        public SchoolRecordsController(IApplicationServiceUser applicationServiceUser, IApplicationServiceSchoolRecords applicationServiceSchoolRecords)
        {
            _applicationServiceUser = applicationServiceUser;
            _applicationServiceSchoolRecords = applicationServiceSchoolRecords;
        }

        [HttpPost]
        [Route("file")]
        public async Task<IActionResult> FormFile([FromBody] SchoolRecordsDto schoolRecordsDto)
        {
            try
            {
                if (schoolRecordsDto == null)
                    return BadRequest("Problemas ao retornar arquivo.");

                var fileName = System.IO.Path.GetFileName(schoolRecordsDto.Path);
                var content = await System.IO.File.ReadAllBytesAsync(schoolRecordsDto.Path);
                new FileExtensionContentTypeProvider()
                    .TryGetContentType(fileName, out string contentType);
                return File(content, contentType, fileName);

            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("message", ex.Message);
                return BadRequest(this.ModelState.ReturnErrosModel());
            }
        }

        // GET api/values
        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            try
            {
                var schoolRecords = await _applicationServiceSchoolRecords.GetById(id);
                if (schoolRecords != null)
                {
                    var fileName = System.IO.Path.GetFileName(schoolRecords.Path);
                    var content = await System.IO.File.ReadAllBytesAsync(schoolRecords.Path);
                    new FileExtensionContentTypeProvider()
                        .TryGetContentType(fileName, out string contentType);
                    return File(content, contentType, fileName);
                    
                }

                return BadRequest("Arquivo não encontrado.");

            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("message", ex.Message);
                return BadRequest(this.ModelState.ReturnErrosModel());
            }
        }

        
        
    }
}
