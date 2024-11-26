using Microsoft.AspNetCore.Components;

namespace BabyTravel.UI.Client.Components
{
    public partial class RequiredField
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public string ValidationMessage { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
