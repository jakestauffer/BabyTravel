using Microsoft.AspNetCore.Components;

namespace BabyTravel.UI.Client.Components
{
    public partial class RedirectToLogin
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            NavigationManager.NavigateTo("/Login", true);
        }
    }
}
