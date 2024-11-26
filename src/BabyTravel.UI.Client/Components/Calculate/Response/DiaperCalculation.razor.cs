using BabyTravel.Api.Client;
using Microsoft.AspNetCore.Components;

namespace BabyTravel.UI.Client.Components.Calculate.Response
{
    public partial class DiaperCalculation
    {
        [Parameter]
        public CalculateDiaperResponse Calculation { get; set; }
    }
}
