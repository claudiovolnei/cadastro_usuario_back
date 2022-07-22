using Microsoft.AspNetCore.Mvc;
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

        // GET api/values
        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            try
            {
                var user = await _applicationServiceUser.GetById(id);
                if (user != null && user.SchoolRecords != null)
                {
                    var file = await _applicationServiceSchoolRecords.DownloadFile(user.SchoolRecords);
                    return File(file.MemoryStream, file.MimeType(file.Path), Path.GetFileName(file.Path));
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
