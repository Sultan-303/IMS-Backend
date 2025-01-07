using AutoMapper;
using IMS.BLL.DTOs.Auth;
using IMS.DAL.Entities;

namespace IMS.DAL.Mapping
{
    public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegisterDTO, User>();
        CreateMap<User, UserDTO>();
        CreateMap<User, AdminUserDTO>();
        CreateMap<UserDTO, UpdateUserDTO>();
        CreateMap<UpdateUserDTO, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.PreCondition(
                (src, dest, context) => !string.IsNullOrEmpty(src.Password)))
            .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => 
                srcMember != null && 
                !opts.DestinationMember.Name.Equals("PasswordHash")));
    }
}
}