using BabyTravel.Api.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen.Blazor.Rendering;
using Radzen.Blazor;
using Radzen;
using BabyTravel.UI.Client.Models.Calculate.Forms;
using BabyTravel.UI.Client.Helpers;

namespace BabyTravel.UI.Client.Components.Calculate
{
    public partial class Calculator<TRequestForm, TResponse>
        where TRequestForm : class, IWithBabyBirthday, new()
        where TResponse : class, new()
    {
        [Parameter]
        public Func<ICalculateClient, TRequestForm, Task<TResponse>> Calculate { get; set; }

        [Parameter]
        public RenderFragment<TRequestForm>? AdditionalTravelInputs { get; set; }

        [Parameter]
        public RenderFragment<TResponse> DisplayResponseConent { get; set; }

        [Inject]
        protected ICalculateClient CalculateClient { get; set; }

        [Inject]
        private NotificationService NotificationService { get; set; }

        [Inject]
        private ClientHelper ClientHelper { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        private string[] _calculationTypes = Enum.GetNames<CalculationType>();

        private bool _isCalculating;

        private bool _isTraveling;

        private TResponse? _response = null;

        private TRequestForm _form = new();

        private bool _canInputTravel;

        protected override void OnInitialized()
        {
            _canInputTravel = _form is IWithTravelDates;

            base.OnInitialized();
        }

        private async Task OnSubmit(TRequestForm request)
        {
            _isCalculating = true;

            await ClientHelper.ExecuteAndNotifySuccessAndErrorsAsync(async () => _response = await Calculate(CalculateClient, request));

            _isCalculating = false;
        }
    }
}
