using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Auth;
using Microsoft.AspNetCore.Components;

namespace BabyTravel.UI.Client.Components
{
    public partial class Header
    {
        [Inject]
        public IUserClient UserClient { get; set; }

        [Inject]
        private CustomAuthStateProvider CustomAuthStateProvider { get; set; }

        private bool _loggingOut;

        private void Logout()
        {
            _loggingOut = true;

            //await customauthstateprovider.logoutasync();
        }
    }
}
