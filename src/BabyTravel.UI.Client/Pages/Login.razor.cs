using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Auth;
using BabyTravel.UI.Client.Helpers;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.ComponentModel.DataAnnotations;

namespace BabyTravel.UI.Client.Pages
{
    public partial class Login
    {
        [Inject]
        public IUserClient UserClient { get; set; }

        [Inject]
        private NotificationService NotificationService { get; set; }

        [Inject]
        private ClientHelper ClientHelper { get; set; }

        [Inject]
        private CustomAuthStateProvider CustomAuthStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string _email = null;
        private string _password = null;

        private bool _registering = false;
        private bool _submitting = false;

        private async Task OnSubmitAsync(LoginArgs args)
        {
            _submitting = true;

            _email = args.Username;
            _password = args.Password;

            if (!IsValidEmail(_email))
            {
                NotificationService.Notify(NotificationSeverity.Error, summary: "Error", detail: "Invalid email");

                _submitting = false;

                return;
            }

            await ClientHelper.ExecuteAndNotifyErrorsOnlyAsync(async () =>
            {
                if (_registering)
                {
                    await UserClient.RegisterAsync(new UserCreateRequest()
                    {
                        Email = _email,
                        Password = _password,
                    });
                }

                await CustomAuthStateProvider.LoginAsync(_email, _password);

                NavigationManager.NavigateTo("/Home");
            });

            _submitting = false;
        }

        private void OnRegister() => _registering = !_registering;

        private bool IsValidEmail(string email)
        {
            var emailValidation = new EmailAddressAttribute();

            return emailValidation.IsValid(email);
        }
    }
}
