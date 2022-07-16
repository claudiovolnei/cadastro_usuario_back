using AutoMapper;
using RegistrationUsers.Application.Dto;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Application.Mappers
{
    public class MappingUsuario : Profile
    {
        public MappingUsuario()
        {
            CreateMap<UsuarioDto, Usuario>().ReverseMap();
        }
    }
}
