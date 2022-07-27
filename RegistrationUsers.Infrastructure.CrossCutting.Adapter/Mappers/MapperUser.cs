using Microsoft.AspNetCore.Mvc;
using RegistrationUsers.Application.Dto.Dto;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.CrossCutting.Adapter.Interface;

namespace RegistrationUsers.Infrastructure.CrossCutting.Adapter.Mappers
{
    public class MapperUser : IMapperUser
    {
        private readonly IMapperSchoolRecords _mapperSchoolRecords;
        private readonly IMapperScholarity _mapperScholarity;
        private int _id;
        public MapperUser(IMapperSchoolRecords mapperSchoolRecords, IMapperScholarity mapperScholarity)
        {
            _mapperSchoolRecords = mapperSchoolRecords;
            _mapperScholarity = mapperScholarity;
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
                SchoolRecordsId = user.SchoolRecordsId,
                SchoolRecords = user.SchoolRecords == null ? null : _mapperSchoolRecords.MapperToDto(user.SchoolRecords),
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
            user.SchoolRecordsId = userDto.SchoolRecordsId.Value;
            user.SchoolRecords = userDto.SchoolRecords.HasValue ? _mapperSchoolRecords.MapperToEntity(userDto.SchoolRecords.Value) : null;
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
                SchoolRecordsId = userDto.SchoolRecordsId.Value,
                SchoolRecords = userDto.SchoolRecords.HasValue? _mapperSchoolRecords.MapperToEntity(userDto.SchoolRecords.Value) : null,
                Lastname = userDto.Lastname
            };
        }

        public IEnumerable<UserDto> MapperToListUserDto(IEnumerable<User> users)
        {
            var userDtoList = new List<UserDto>();

            foreach (var user in users)
            {
                var userDto = new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    BirthDate = user.BirthDate,
                    Email = user.Email,                    
                    ScholarityId = String.IsNullOrEmpty(user.ScholarityId.ToString()) ? String.Empty : user.ScholarityId.ToString(),
                    Scholarity = user.Scholarity == null ? null : _mapperScholarity.MapperToDto(user.Scholarity),
                    SchoolRecordsId = user.SchoolRecordsId,
                    SchoolRecords = user.SchoolRecords == null ? null : _mapperSchoolRecords.MapperToDto(user.SchoolRecords),
                    Lastname = user.Lastname
                };

                if(userDto.SchoolRecords != null)
                    userDto.Blob = ConvertFile(user.SchoolRecords);

                userDtoList.Add(userDto);
            }

            return userDtoList;
        }

        private byte[] ConvertFile(SchoolRecords schoolRecords)
        {
            FileStream fs = new FileStream(schoolRecords.Path, FileMode.Open, FileAccess.Read);

            //The reader reads the binary data from the file stream  
            BinaryReader reader = new BinaryReader(fs);

            //Bytes from the binary reader stored in BlobValue array  
            return  reader.ReadBytes((int)fs.Length);
        }
    }
}
