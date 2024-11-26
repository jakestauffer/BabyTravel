using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Models.Trip;
using Microsoft.AspNetCore.Components;

namespace BabyTravel.UI.Client.Components.Trip
{
    public partial class TripDialog
    {
        [Parameter]
        public Models.Trip.Trip Trip { get; set; }

        [Inject]
        public ITripClient TripClient { get; set; }

        private bool _submitting;

        private async Task SubmitAsync()
        {
            _submitting = true;

            if (Trip.Id == 0)
            {
                await TripClient.CreateAsync(new TripCreateRequest()
                {
                    Start = Trip.Start,
                    End = Trip.End,
                    Name = Trip.Name
                });
            }
            else
            {
                await TripClient.UpdateAsync(new TripUpdateRequest()
                {
                    Id = Trip.Id,
                    Start = Trip.Start,
                    End = Trip.End,
                    Name = Trip.Name
                });
            }

            _submitting = false;

            StateHasChanged();
        }
    }
}
