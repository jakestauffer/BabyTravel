using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Models.Calculate.Forms;
using BabyTravel.UI.Client.Models.Calculate.Responses;

namespace BabyTravel.UI.Client.Components.Calculate
{
    public partial class TripCalculator
    {
        private static Func<ICalculateClient, CalculateTripForm, Task<CalculateTripResponse>> CalculateTripAsync = async (calculateClient, form) =>
        {
            return new CalculateTripResponse()
            {
                DiaperResponse = await calculateClient.DiapersAsync(new CalculateDiaperRequest()
                {
                    BabyBirthday = form.BabyBirthday,
                    TravelStartDate = form.TravelStartDate,
                    TravelEndDate = form.TravelEndDate
                }),
                MealResponse = await calculateClient.MealsAsync(new CalculateMealRequest()
                {
                    BabyBirthday = form.BabyBirthday,
                    TravelStartDate = form.TravelStartDate,
                    TravelEndDate = form.TravelEndDate
                }),
                OutfitResponse = await calculateClient.OutfitsAsync(new CalculateOutfitRequest()
                {
                    BabyBirthday = form.BabyBirthday,
                    TravelStartDate = form.TravelStartDate,
                    TravelEndDate = form.TravelEndDate,
                    WashingFrequencyInDays = form.WashingFrequencyInDays
                }),
                SleepResponse = await calculateClient.SleepAsync(new CalculateSleepRequest()
                {
                    BabyBirthday = form.BabyBirthday
                }),
            };
        };
    }
}
