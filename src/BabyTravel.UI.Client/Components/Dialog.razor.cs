using Microsoft.AspNetCore.Components;
using Radzen;

namespace BabyTravel.UI.Client.Components
{
    public partial class Dialog<T>
        where T : ComponentBase
    {
        [Inject]
        public DialogService DialogService { get; set; }

        [Parameter]
        public Dictionary<string, object> Parameters { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public bool Open { get; set; }

        [Parameter]
        public EventCallback<bool> OpenChanged { get; set; }

        [Parameter]
        public EventCallback OnClose { get; set; }

        protected async override Task OnParametersSetAsync()
        {
            if (Open)
            {
                await DialogService.OpenAsync<T>(
                     Title,
                     Parameters,
                     new DialogOptions()
                     {
                         Width = "auto",
                         Height = "auto"
                     });

                Open = false;
                await OpenChanged.InvokeAsync(Open);

                await OnClose.InvokeAsync();
            }
        }
    }
}
