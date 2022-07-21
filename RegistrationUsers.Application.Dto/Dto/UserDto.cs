using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RegistrationUsers.Application.Dto.Dto
{
    public record class UserDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Sobrenome é obrigatório.")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; set; }
        [CheckBirthDate(ErrorMessage = "Data de nascimento não pode ser maior que a atual.")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Escolaridade obrigatório.")]
        public string ScholarityId { get; set; }
        public ScholarityDto Scholarity { get; set; }
        public SchoolRecordsDto SchoolRecords { get; set; }
        [Required(ErrorMessage = "Histórico escolar deve ser anexado")]
        public IFormFile File { get; set; }
    }

    public class CheckBirthDate : ValidationAttribute
    {
        public CheckBirthDate()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if (dt >= DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
