using BabyTravel.Api.Models.Calculate.Diapers;
using BabyTravel.Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using BabyTravel.Data.Repositories.Abstractions;
using BabyTravel.Api.Models.Shared;
using BabyTravel.Api.Models.Baby;
using BabyTravel.Data.Repositories;
using AutoMapper;
using BabyTravel.Api.Controllers.Base;
using System.Linq.Expressions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using BabyTravel.Data.Models;

namespace BabyTravel.Api.Controllers
{
    public class BabyController :
        DatabaseController
        .WithRepository<IBabyRepository, Data.Models.Baby>
        .WithGet<string, BabyResponse>
        .WithCreate<BabyCreateRequest, BabyResponse>
        .WithUpdate<BabyUpdateRequest, BabyResponse>
    {
        private IUserRepository _userRepository;

        public BabyController(IBabyRepository repository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(repository, userRepository, httpContextAccessor, mapper)
        {
        }

        public async override Task<IEnumerable<BabyResponse>> GetAll()
        {
            var entities = await _repository.GetBabiesByUserAsync(_user.Email);

            return entities.ConvertAll(baby => new BabyResponse()
            {
                Id = baby.Id,
                Name = baby.Name,
                BabyBirthday = baby.Birthday
            });
        }

        public override async Task<BabyResponse> Create(BabyCreateRequest createRequest)
        {
            var babyToAdd = _mapper.Map<BabyCreateRequest, Data.Models.Baby>(createRequest);
            babyToAdd.UserId = _user.Id;

            var savedBaby = await _repository.AddAsync(babyToAdd);

            return _mapper.Map<Data.Models.Baby, BabyResponse>(savedBaby);
        }

        public override async Task<BabyResponse> Update(BabyUpdateRequest updateRequest)
        {
            var babyToUpdate = _mapper.Map<BabyUpdateRequest, Data.Models.Baby>(updateRequest);
            babyToUpdate.UserId = _user.Id;

            var savedBaby = await _repository.UpdateAsync(babyToUpdate);

            return _mapper.Map<Data.Models.Baby, BabyResponse>(savedBaby);
        }

        protected override Expression<Func<Data.Models.Baby, bool>> GetQuery(string name) =>
            baby => baby.Name == name && baby.UserId == _user.Id;
    }
}
