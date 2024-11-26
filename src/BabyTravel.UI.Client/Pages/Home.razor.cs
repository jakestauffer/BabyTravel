using Radzen.Blazor;
using Radzen;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BabyTravel.UI.Client.Pages
{
    public partial class Home
    {
        [CascadingParameter]
        private Task<AuthenticationState>? AuthenticationState { get; set; }
    }
}
