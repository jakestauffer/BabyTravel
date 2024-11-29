using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using BabyTravel.Api.Client;
using System.Net.Http.Json;
using BabyTravel.UI.Client.Models.User;
using User = BabyTravel.UI.Client.Models.User.User;
using Radzen;
using Microsoft.AspNetCore.Http;
using BabyTravel.UI.Client.Helpers;

namespace BabyTravel.UI.Client.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IUserClient _userClient;
        private readonly NotificationService _notificationService;
        private readonly ClientHelper _clientHelper;

        private ClaimsPrincipal _claimsPrincipal;
        private User? _user;

        public CustomAuthStateProvider(
            IUserClient userClient,
            NotificationService notificationService,
            ClientHelper clientHelper) 
        {
            _userClient = userClient;
            _notificationService = notificationService;
            _clientHelper = clientHelper;
            _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_user == null)
            {
                try
                {
                    var user = await _userClient.GetUserProfileAsync();

                    if (user != null)
                    {
                        _user = new User()
                        {
                           Email = user.Email
                        };

                        _claimsPrincipal = GetClaimsPrincipleFor(_user);
                    }
                }
                catch (ApiException<ErrorResponse> ex)
                {
                    _notificationService.Notify(NotificationSeverity.Error, summary: "Error", detail: ex.Result.Message);
                }
                catch
                {
                    // ignore
                }
            }

            return new AuthenticationState(_claimsPrincipal);
        }

        public Task LoginAsync(string email, string password) =>
            _clientHelper.ExecuteAndNotifyErrorsOnlyAsync(async () => 
            {
                await _userClient.LoginAsync(new UserLoginRequest()
                {
                    Email = email,
                    Password = password
                });

                _user = new User()
                {
                    Email = email
                };

                _claimsPrincipal = GetClaimsPrincipleFor(_user);

                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            });

        public Task LogoutAsync() =>
            _clientHelper.ExecuteAndNotifyErrorsOnlyAsync(async () =>
            {
                await _userClient.LogoutAsync();

                _user = null;

                _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());

                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            });

        private ClaimsPrincipal GetClaimsPrincipleFor(User user) =>
            new ClaimsPrincipal(
                new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Email, user.Email),
                ],
                Constants.Authentication.Scheme));
    }
}
