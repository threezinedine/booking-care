using AutoMapper;
using BookingCare.API.Constants;
using BookingCare.API.Models;
using BookingCare.Shared.ModelDtos;

namespace BookingCare.API.Profiles
{
	public class AutoMapperProfile : Profile
	{
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role_Vi, opt => opt.MapFrom(src => src.Role.Name_Vi))
                .ForMember(dest => dest.Role_En, opt => opt.MapFrom(src => src.Role.Name_En))
                .ForMember(dest => dest.Specialty_En, opt => opt.MapFrom(src => src.Specialty.Name_En))
                .ForMember(dest => dest.Specialty_Vi, opt => opt.MapFrom(src => src.Specialty.Name_Vi))
                .ForMember(dest => dest.Position_En, opt => opt.MapFrom(src => src.Position.Name_En))
                .ForMember(dest => dest.Position_Vi, opt => opt.MapFrom(src => src.Position.Name_Vi))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => string.Empty));
            CreateMap<UserDto, User>();
        }
    }
}
