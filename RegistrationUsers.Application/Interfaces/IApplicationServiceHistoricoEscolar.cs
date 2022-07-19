using RegistrationUsers.Application.Dto.Dto;

namespace RegistrationUsers.Application.Interfaces
{
    public interface IApplicationServiceHistoricoEscolar
    {
        void Add(HistoricoEscolarDto obj);

        HistoricoEscolarDto? GetById(int id);

        bool Update(HistoricoEscolarDto obj);

        bool Remove(int id);

        void Dispose();
    }
}
