using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Models.Baby;
using Microsoft.AspNetCore.Components;

namespace BabyTravel.UI.Client.Components.Baby
{
    public partial class BabyDialog
    {
        [Parameter]
        public Models.Baby.Baby Baby { get; set; }

        [Inject]
        public IBabyClient BabyClient { get; set; }

        private bool _submitting;

        private async Task SubmitAsync()
        {
            _submitting = true;

            if (Baby.Id == 0)
            {
                await BabyClient.CreateAsync(new BabyCreateRequest()
                {
                    BabyBirthday = Baby.Birthday,
                    Name = Baby.Name
                });
            }
            else
            {
                await BabyClient.UpdateAsync(new BabyUpdateRequest()
                {
                    Id = Baby.Id,
                    BabyBirthday = Baby.Birthday,
                    Name = Baby.Name
                });
            }

            _submitting = false;

            StateHasChanged();
        }
    }
}
