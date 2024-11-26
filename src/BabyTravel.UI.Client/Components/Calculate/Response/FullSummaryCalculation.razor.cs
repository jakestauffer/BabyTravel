using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Models.Baby;
using BabyTravel.UI.Client.Models.Calculate.Responses;
using Microsoft.AspNetCore.Components;

namespace BabyTravel.UI.Client.Components.Calculate.Response
{
    public partial class FullSummaryCalculation
    {
        [Parameter]
        public CalculateTripResponse CalculateTripResponse { get; set; }
    }
}
