using RegistrationUsers.Application.Dto.Dto;

namespace RegistrationUsers.Application.Interfaces
{
    public interface IApplicationServiceEscolaridade
    {
        void Dispose();
        IEnumerable<EscolaridadeDto> GetAll();
    }
}
