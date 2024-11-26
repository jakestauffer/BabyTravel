using AutoMapper;
using BabyTravel.Api.Models.Baby;

namespace BabyTravel.Api.MappingProfiles
{
    public class BabyControllerMappingProfile : Profile
    {
        public BabyControllerMappingProfile() 
        {
            CreateMap<BabyCreateRequest, Data.Models.Baby>()
                .ForMember(src => src.Birthday, opt => opt.MapFrom(dest => dest.BabyBirthday));
            CreateMap<Data.Models.Baby, BabyResponse>()
                .ForMember(src => src.BabyBirthday, opt => opt.MapFrom(dest => dest.Birthday));

            CreateMap<BabyUpdateRequest, Data.Models.Baby>()
                .ForMember(src => src.Birthday, opt => opt.MapFrom(dest => dest.BabyBirthday));
            CreateMap<BabyUpdateRequest, BabyResponse>()
                .ForMember(src => src.BabyBirthday, opt => opt.MapFrom(dest => dest.BabyBirthday));
        }
    }
}
