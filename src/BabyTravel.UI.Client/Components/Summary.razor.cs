using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Extensions;
using BabyTravel.UI.Client.Helpers;
using BabyTravel.UI.Client.Models.Calculate.Responses;
using BabyTravel.UI.Client.Models.Trip;
using Microsoft.AspNetCore.Components;

namespace BabyTravel.UI.Client.Components
{
    public partial class Summary
    {
        [Inject]
        public ITripClient TripClient { get; set; }

        [Inject]
        public CalculationHelper CalculationHelper { get; set; }

        private TripResponse? _currentTrip;
        private TripResponse? _nextTrip;
        private CalculateBabyTripResponse _calculateBabyCurrentTripResponse;
        private CalculateBabyTripResponse _calculateBabyNextTripResponse;
        private bool _isLoading;

        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;

            var trips = await TripClient.GetAllAsync();

            _currentTrip = trips.FirstOrDefault(x => x.Start <= DateTime.Today && x.End >= DateTime.Today);
            _nextTrip =
                trips
                .Where(t => t.Start > DateTime.Today && t.End > DateTime.Today)
                .MinBy(x => x.Start.Date - DateTime.Today.Date);

            if (_currentTrip != null)
            {
                _calculateBabyCurrentTripResponse = (await CalculationHelper.GetCalculationsForBabiesAsync(new Models.Trip.Trip()
                {
                    Name = _currentTrip.Name,
                    Start = _currentTrip.Start.Date,
                    End = _currentTrip.End.Date
                })).Summarize();
            }

            if (_nextTrip != null)
            {
                _calculateBabyNextTripResponse = (await CalculationHelper.GetCalculationsForBabiesAsync(new Models.Trip.Trip()
                {
                    Name = _nextTrip.Name,
                    Start = _nextTrip.Start.Date,
                    End = _nextTrip.End.Date
                })).Summarize();
            }

            _isLoading = false;
        }
    }
}
