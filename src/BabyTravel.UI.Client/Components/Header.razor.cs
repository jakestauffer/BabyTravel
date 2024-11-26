using BabyTravel.Api.Client;
using Microsoft.AspNetCore.Components;

namespace BabyTravel.UI.Client.Components
{
    public partial class Header
    {
        [Inject]
        public IUserClient UserClient { get; set; }

        private bool _loggingOut;

        private async Task LogoutAsync()
        {
            _loggingOut = true;

            await UserClient.LogoutAsync();
        }
    }
}
