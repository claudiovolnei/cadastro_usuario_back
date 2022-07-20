using Microsoft.AspNetCore.Http;
using RegistrationUsers.Application.Dto.Dto;

namespace RegistrationUsers.Application.Interfaces
{
    public interface IApplicationServiceHistoricoEscolar
    {
        Task<HistoricoEscolarDto> Add(IFormFile file);

        Task<HistoricoEscolarDto>? GetById(int id);

        Task<bool> Update(HistoricoEscolarDto obj);

        Task<bool> Remove(int id);

        void Dispose();
    }
}
