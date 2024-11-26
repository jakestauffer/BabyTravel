using Microsoft.AspNetCore.Components;
using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Models.Calculate.Forms;

namespace BabyTravel.UI.Client.Components.Calculate
{
    public partial class DiaperCalculator
    {
        private static Func<ICalculateClient, CalculateDiaperForm, Task<CalculateDiaperResponse>> CalculateDiapersAsync = async (calculateClient, form) =>
        {
            return await calculateClient.DiapersAsync(new CalculateDiaperRequest()
            {
                BabyBirthday = form.BabyBirthday,
                TravelStartDate = form.TravelStartDate,
                TravelEndDate = form.TravelEndDate
            });
        };
    }
}
