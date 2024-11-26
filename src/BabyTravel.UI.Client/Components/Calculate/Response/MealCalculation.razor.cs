using BabyTravel.Api.Client;
using Microsoft.AspNetCore.Components;

namespace BabyTravel.UI.Client.Components.Calculate.Response
{
    public partial class MealCalculation
    {
        [Parameter]
        public CalculateMealResponse Calculation { get; set; }
    }
}
