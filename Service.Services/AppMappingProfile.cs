using AutoMapper;
using Service.Domain.ModelsDb;
using Service.Domain.ViewModels.LoginAndRegistration;

namespace Service.Services
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UserDb, LoginViewModel>().ReverseMap();
            CreateMap<UserDb, RegisterViewModel>().ReverseMap();

            CreateMap<RegisterViewModel, ConfirmEmailViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.Password))
                .ReverseMap();
        }
    }
}
