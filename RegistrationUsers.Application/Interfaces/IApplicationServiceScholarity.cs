using RegistrationUsers.Application.Dto.Dto;

namespace RegistrationUsers.Application.Interfaces
{
    public interface IApplicationServiceScholarity
    {
        void Dispose();
        Task<IEnumerable<ScholarityDto>> GetAll();
    }
}
