using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Models.Calculate.Forms;

namespace BabyTravel.UI.Client.Components.Calculate
{
    public partial class MealCalculator
    {
        private static Func<ICalculateClient, CalculateMealForm, Task<CalculateMealResponse>> CalculateMealsAsync = async (calculateClient, form) =>
        {
            return await calculateClient.MealsAsync(new CalculateMealRequest()
            {
                BabyBirthday = form.BabyBirthday,
                TravelStartDate = form.TravelStartDate,
                TravelEndDate = form.TravelEndDate
            });
        };
    }
}
