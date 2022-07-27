using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface
{
   public interface IMapperUser
   {
        void MapperToEntity(UserDto userDto, ref User user);
        User MapperToEntity(UserDto userDto);
        UserDto MapperToDto(User user);
        IEnumerable<UserDto> MapperToListUserDto(IEnumerable<User> users);
   } 
}
    
