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
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => string.Empty));
            CreateMap<UserDto, User>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<Specialty, SpecialtyDto>();
            CreateMap<SpecialtyDto, Specialty>()
                .ForMember(dest => dest.Doctors, opt => opt.Ignore());

            CreateMap<Position, PositionDto>();
            CreateMap<PositionDto, Position>();

            CreateMap<ScheduleTime, ScheduleTimeDto>();
            CreateMap<ScheduleTimeDto, ScheduleTime>();
        }
    }
}
