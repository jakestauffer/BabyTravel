using AutoMapper;
using BabyTravel.Api.Exceptions;
using BabyTravel.Api.Models.Shared;
using BabyTravel.Data.Models;
using BabyTravel.Data.Repositories;
using BabyTravel.Data.Repositories.Abstractions;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;
using System.Security.Claims;
using System.Security.Policy;
using static BabyTravel.Api.Controllers.Base.DatabaseController;

namespace BabyTravel.Api.Controllers.Base
{
    public static class DatabaseController
    {
        public static class WithRepository<TRepository, TEntity>
            where TEntity : class
            where TRepository : IRepository<TEntity>
        {
            public static class WithGet<TQueryRequest, TQueryResponse>
            {
                public static class WithCreate<TCreateRequest, TCreateResponse>
                {
                    [Authorize]
                    [ApiController]
                    [Route("[controller]/[action]")]
                    public abstract class WithUpdate<TUpdateRequest, TUpdateResponse> : ControllerBase
                    {
                        protected readonly TRepository _repository;
                        protected readonly IMapper _mapper;
                        protected User _user;

                        protected WithUpdate(TRepository repository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
                        {
                            _repository = repository;
                            _mapper = mapper;

                            var email = httpContextAccessor.HttpContext!.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                            _user = userRepository.FirstOrDefaultAsync(u => u.Email == email).Result!;
                        }

                        [Authorize]
                        [HttpGet]
                        public virtual async Task<IEnumerable<TQueryResponse>> GetAll()
                        {
                            var entities = await _repository.GetAllAsync();

                            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TQueryResponse>>(entities);
                        }

                        [Authorize]
                        [HttpPost]
                        [ProducesResponseType((int)HttpStatusCode.OK)]
                        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.NotFound)]
                        public virtual async Task<TQueryResponse?> Get(TQueryRequest queryRequest)
                        {
                            var entity = await _repository.FirstOrDefaultAsync(GetQuery(queryRequest));

                            return 
                                entity != null
                                ? _mapper.Map<TEntity, TQueryResponse>(entity)
                                : throw new NotFoundException($"{typeof(TEntity).Name} not found");
                        }

                        protected abstract Expression<Func<TEntity, bool>> GetQuery(TQueryRequest queryRequest);

                        [Authorize]
                        [HttpPost]
                        [ProducesResponseType((int)HttpStatusCode.OK)]
                        public virtual async Task<TCreateResponse> Create(TCreateRequest createRequest)
                        {
                            var entity = _mapper.Map<TCreateRequest, TEntity>(createRequest);

                            var savedEntity = await _repository.AddAsync(entity);

                            var response = _mapper.Map<TEntity, TCreateResponse>(savedEntity);

                            return response;
                        }

                        [Authorize]
                        [HttpPatch]
                        [ProducesResponseType((int)HttpStatusCode.OK)]
                        public virtual async Task<TUpdateResponse> Update(TUpdateRequest updateRequest)
                        {
                            var entity = _mapper.Map<TUpdateRequest, TEntity>(updateRequest);

                            var savedEntity = await _repository.UpdateAsync(entity);

                            var response = _mapper.Map<TEntity, TUpdateResponse>(savedEntity);

                            return response;
                        }

                        [Authorize]
                        [HttpDelete("{id}")]
                        [ProducesResponseType((int)HttpStatusCode.OK)]
                        public virtual async Task Delete(int id)
                        {
                            var entity = await _repository.GetByIdAsync(id);

                            if (entity == null)
                            {
                                throw new NotFoundException($"{typeof(TEntity).Name} not found");
                            }

                            await _repository.DeleteByIdAsync(id);
                        }
                    }
                }
            }
        }
    }
}
