using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Models.Calculate.Forms;

namespace BabyTravel.UI.Client.Components.Calculate
{
    public partial class SleepCalculator
    {
        private static Func<ICalculateClient, CalculateSleepForm, Task<CalculateSleepResponse>> CalculateSleepAsync = async (calculateClient, form) =>
        {
            return await calculateClient.SleepAsync(new CalculateSleepRequest()
            {
                BabyBirthday = form.BabyBirthday
            });
        };
    }
}
