using AutoMapper;
using System.Linq.Expressions;
using System.Security.Claims;
using BabyTravel.Api.Models.Trip;
using BabyTravel.Data.Repositories.Abstractions;
using BabyTravel.Api.Controllers.Base;
using BabyTravel.Data.Models;

namespace TripTravel.Api.Controllers
{
    public class TripController :
        DatabaseController
        .WithRepository<ITripRepository, Trip>
        .WithGet<string, TripResponse>
        .WithCreate<TripCreateRequest, TripResponse>
        .WithUpdate<TripUpdateRequest, TripResponse>
    {
        public TripController(ITripRepository repository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(repository, userRepository, httpContextAccessor, mapper)
        {
        }

        public async override Task<IEnumerable<TripResponse>> GetAll()
        {
            var entities = await _repository.GetTripsByUserAsync(_user.Email);

            return entities.ConvertAll(trip => new TripResponse()
            {
                Id = trip.Id,
                Name = trip.Name,
                Start = trip.Start,
                End = trip.End
            });
        }

        // TODO: Consider way to centralize handling entities that relate to user
        public override async Task<TripResponse> Create(TripCreateRequest createRequest)
        {
            var email =
                User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Email)
                ?.Value;

            var tripToAdd = _mapper.Map<TripCreateRequest, Trip>(createRequest);
            tripToAdd.UserId = _user.Id;

            var savedTrip = await _repository.AddAsync(tripToAdd);

            return _mapper.Map<Trip, TripResponse>(savedTrip);
        }

        public override async Task<TripResponse> Update(TripUpdateRequest updateRequest)
        {
            var tripToUpdate = _mapper.Map<TripUpdateRequest, Trip>(updateRequest);
            tripToUpdate.UserId = _user.Id;

            var savedTrip = await _repository.UpdateAsync(tripToUpdate);

            return _mapper.Map<Trip, TripResponse>(savedTrip);
        }


        protected override Expression<Func<Trip, bool>> GetQuery(string queryRequest) =>
            trip => trip.Name == queryRequest && trip.UserId == _user.Id;
    }
}
