using AutoMapper;
using IMS.BLL.DTOs.Auth;
using IMS.DAL.Entities;
using IMS.BLL.DTOs.Inventory;

namespace IMS.DAL.Mapping
{
    public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Item mappings
            CreateMap<Item, ItemDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ItemID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<ItemDTO, Item>()
                .ForMember(dest => dest.ItemID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        
        // Stock Mappings
            CreateMap<Stock, StockDTO>();
            CreateMap<StockDTO, Stock>()
                .ForMember(dest => dest.User, opt => opt.Ignore()); // Ignore navigation property

        // User Mappings
        CreateMap<UpdateUserDTO, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.PreCondition(
                (src, dest, context) => !string.IsNullOrEmpty(src.Password)))
            .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => 
                srcMember != null && 
                !opts.DestinationMember.Name.Equals("PasswordHash")));

        CreateMap<RegisterDTO, User>();
        CreateMap<User, UserDTO>();
        CreateMap<User, AdminUserDTO>();
        CreateMap<UserDTO, UpdateUserDTO>();

        // Category Mappings
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

        CreateMap<UpdateItemDTO, Item>()
                .ForMember(dest => dest.ItemID, opt => opt.MapFrom(src => src.Id))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<UpdateStockDTO, Stock>()
                .ForMember(dest => dest.StockID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ItemID, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}