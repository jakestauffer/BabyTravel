using Microsoft.AspNetCore.Components;
using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Models.Calculate.Forms;

namespace BabyTravel.UI.Client.Components.Calculate
{
    public partial class OutfitCalculator
    {
        private static Func<ICalculateClient, CalculateOutfitForm, Task<CalculateOutfitResponse>> CalculateOutfitsAsync = async (calculateClient, form) =>
        {
            return await calculateClient.OutfitsAsync(new CalculateOutfitRequest()
            {
                BabyBirthday = form.BabyBirthday,
                TravelStartDate = form.TravelStartDate,
                TravelEndDate = form.TravelEndDate,
                WashingFrequencyInDays = 0
            });
        };
    }
}
