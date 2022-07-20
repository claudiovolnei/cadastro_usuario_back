using RegistrationUsers.Application.Dto.Dto;

namespace RegistrationUsers.Application.Interfaces
{
    public interface IApplicationServiceEscolaridade
    {
        void Dispose();
        Task<IEnumerable<EscolaridadeDto>> GetAll();
    }
}
