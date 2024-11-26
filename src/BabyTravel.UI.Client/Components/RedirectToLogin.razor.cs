using BabyTravel.UI.Client.Auth;
using Microsoft.AspNetCore.Components;

namespace BabyTravel.UI.Client.Components
{
    public partial class RedirectToLogin
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        private CustomAuthStateProvider CustomAuthStateProvider { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            await CustomAuthStateProvider.LogoutAsync();

            NavigationManager.NavigateTo("/", true);
        }
    }
}
