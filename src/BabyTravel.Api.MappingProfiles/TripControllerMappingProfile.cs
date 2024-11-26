using AutoMapper;
using BabyTravel.Api.Models.Baby;
using BabyTravel.Api.Models.Trip;

namespace BabyTravel.Api.MappingProfiles
{
    public class TripControllerMappingProfile : Profile
    {
        public TripControllerMappingProfile() 
        {
            CreateMap<TripCreateRequest, Data.Models.Trip>();
            CreateMap<Data.Models.Trip, TripResponse>();

            CreateMap<TripUpdateRequest, Data.Models.Trip>();
            CreateMap<TripUpdateRequest, TripResponse>();
        }
    }
}
