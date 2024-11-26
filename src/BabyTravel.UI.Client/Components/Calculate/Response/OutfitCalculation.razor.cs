using BabyTravel.Api.Client;
using Microsoft.AspNetCore.Components;

namespace BabyTravel.UI.Client.Components.Calculate.Response
{
    public partial class OutfitCalculation
    {
        [Parameter]
        public CalculateOutfitResponse Calculation { get; set; }
    }
}
