using Microsoft.AspNetCore.Http;
using RegistrationUsers.Application.Dto;
using RegistrationUsers.Application.Interfaces;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Application.Services
{
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario _serviceUsuario;
        private readonly IApplicationServiceHistoricoEscolar _aplicationServiceHistoricoEscolar;
        private readonly IMapperUsuario _mapper;
        public ApplicationServiceUsuario(IServiceUsuario serviceUsuario, IMapperUsuario mapper, IApplicationServiceHistoricoEscolar aplicationServiceHistoricoEscolar)
        {
            _serviceUsuario = serviceUsuario;
            _mapper = mapper;
            _aplicationServiceHistoricoEscolar = aplicationServiceHistoricoEscolar;
        }
        public async Task<UsuarioDto> Add(UsuarioDto obj)
        {
            var historicoEscolar = await _aplicationServiceHistoricoEscolar.Add(obj.file);
            if (!historicoEscolar.Id.HasValue)
                throw new Exception("Problemas ao salvar histórico.");

            obj.HistoricoEscolarId = historicoEscolar.Id.Value;
            var usuario = _mapper.MapperToEntity(obj);
            usuario = await _serviceUsuario.Add(usuario);
            return _mapper.MapperToDto(usuario);
        }

        public void Dispose()
        {
            _serviceUsuario.Dispose();
        }

        public async Task<IEnumerable<UsuarioDto>> GetAll()
        {
            var objUsuarios = await _serviceUsuario.GetAll();
            return _mapper.MapperToListUsuariosDto(objUsuarios);
        }

        public async Task<UsuarioDto>? GetById(int id)
        {
            var objUsuario = await _serviceUsuario.GetById(id);
            return _mapper.MapperToDto(objUsuario);
        }

        public async Task<bool> Remove(int id)
        {
            var objUsuario = await _serviceUsuario.GetById(id);

            if (objUsuario != null)
            {
                await _serviceUsuario.Remove(objUsuario);
                return true;
            }

            return false;
        }

        public async Task<bool> Update(UsuarioDto obj)
        {
            var usuario = await _serviceUsuario.GetById(obj.Id.Value);
            if (usuario != null)
            {
                _mapper.MapperToEntity(obj, ref usuario);
                await _serviceUsuario.Update(usuario);
                return true;
            }

            return false;
        }

        
    }
}
