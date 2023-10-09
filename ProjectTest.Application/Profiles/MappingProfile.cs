using AutoMapper;
using ProjectTest.Application.DTOs.PassportUserDto;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Domain;

namespace ProjectTest.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap(); 
            CreateMap<User, UserListDto>().ReverseMap();
            //CreateMap<UserDto, User>().ReverseMap();

            CreateMap<PassportUser, CreatePassportUserDto>().ReverseMap();
            CreateMap<PassportUser, PassportUserDto>().ReverseMap();
            CreateMap<PassportUser, PassportUserListDto>().ReverseMap();

        }
    }
}
