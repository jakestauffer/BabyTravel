using BabyTravel.Api.Client;
using Microsoft.AspNetCore.Components;

namespace BabyTravel.UI.Client.Components.Calculate.Response
{
    public partial class SleepCalculation
    {
        [Parameter]
        public CalculateSleepResponse Calculation { get; set; }
    }
}
