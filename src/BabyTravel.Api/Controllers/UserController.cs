using AutoMapper;
using BabyTravel.Api.Controllers.Base;
using BabyTravel.Api.Exceptions;
using BabyTravel.Api.Models.Shared;
using BabyTravel.Api.Models.User;
using BabyTravel.Data.Contexts;
using BabyTravel.Data.Models;
using BabyTravel.Data.Repositories.Abstractions;
using BabyTravel.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Linq.Expressions;
using System.Net;
using System.Security.Claims;

namespace BabyTravel.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task Login(UserLoginRequest loginRequest)
        {
            var user =
                await _userRepository.FirstOrDefaultAsync(u => 
                u.Email == loginRequest.Email && 
                u.Password == loginRequest.Password);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            await HttpContext.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                    [
                        new Claim(ClaimTypes.Email, user!.Email),
                    ],
                    CookieAuthenticationDefaults.AuthenticationScheme)));
        }

        [Authorize]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync();
        }

        [AllowAnonymous]
        public async Task Register(UserCreateRequest userCreateRequest)
        {
            var user = await _userRepository.AddAsync(_mapper.Map<UserCreateRequest, User>(userCreateRequest));

            await HttpContext.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                    [
                        new Claim(ClaimTypes.Email, user!.Email),
                    ],
                    CookieAuthenticationDefaults.AuthenticationScheme)));
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType<UserResponse>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.NotFound)]
        public async Task<UserResponse> GetUserProfile()
        {
            var email = User.GetUserEmail();

            var user = await _userRepository.FirstOrDefaultAsync(u => u.Email == email);

            return
                user == null
                ? throw new NotFoundException("User not found")
                : new UserResponse()
                {
                    Email = user.Email
                };
        }
    }
}
