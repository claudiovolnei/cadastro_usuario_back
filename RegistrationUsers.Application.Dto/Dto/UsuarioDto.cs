using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RegistrationUsers.Application.Dto
{
    public record class UsuarioDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Sobrenome é obrigatório.")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; set; }
        [CheckBirthDate(ErrorMessage = "Data de nascimento não pode ser maior que a atual.")]
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
        public int HistoricoEscolarId { get; set; }
        [Required(ErrorMessage = "Histórico escolar deve ser anexado")]
        public IFormFile file { get; set; }
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
