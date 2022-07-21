using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Mappers
{
    public class MapperUser : IMapperUser
    {
        private readonly IMapperSchoolRecords _mapperSchoolRecords;
        private int _id;
        public MapperUser(IMapperSchoolRecords mapperSchoolRecords)
        {
            _mapperSchoolRecords = mapperSchoolRecords;
        }

        public UserDto MapperToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                BirthDate = user.BirthDate,
                Email = user.Email,
                ScholarityId = String.IsNullOrEmpty(user.ScholarityId.ToString()) ? String.Empty : user.ScholarityId.ToString(),
                SchoolRecords =  _mapperSchoolRecords.MapperToDto(user.SchoolRecords),
                Lastname = user.Lastname
            };
        }

        public void MapperToEntity(UserDto userDto, ref User user)
        {
            user.Id = userDto.Id == null ? 0 : userDto.Id.Value;
            user.Name = userDto.Name;
            user.BirthDate = userDto.BirthDate;
            user.Email = userDto.Email;
            user.ScholarityId = int.TryParse(userDto.ScholarityId, out _id) ? _id : 0;
            user.SchoolRecords = _mapperSchoolRecords.MapperToEntity(userDto.SchoolRecords);
            user.Lastname = userDto.Lastname;            
        }

        public User MapperToEntity(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id == null ? 0 : userDto.Id.Value,
                Name = userDto.Name,
                BirthDate = userDto.BirthDate,
                Email = userDto.Email,
                ScholarityId = int.TryParse(userDto.ScholarityId, out _id) ? _id : 0,
                SchoolRecords = _mapperSchoolRecords.MapperToEntity(userDto.SchoolRecords),
                Lastname = userDto.Lastname
            };
        }

        public IEnumerable<UserDto> MapperToListUserDto(IEnumerable<User> users)
        {
            var userList = new List<UserDto>();
            foreach (var user in users)
            {
                var userEntity = new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    ScholarityId = String.IsNullOrEmpty(user.ScholarityId.ToString()) ? String.Empty : user.ScholarityId.ToString(),
                    SchoolRecords = _mapperSchoolRecords.MapperToDto(user.SchoolRecords),
                    Lastname = user.Lastname
                };

                userList.Add(userEntity);
            }

            return userList;
        }
    }
}
