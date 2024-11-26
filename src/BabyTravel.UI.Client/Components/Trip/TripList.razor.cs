using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Helpers;
using BabyTravel.UI.Client.Models.Baby;
using BabyTravel.UI.Client.Models.Calculate.Responses;
using BabyTravel.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen.Blazor;
using System.Security.Claims;

namespace BabyTravel.UI.Client.Components.Trip
{
    public partial class TripList
    {
        [CascadingParameter]
        private Task<AuthenticationState>? AuthenticationState { get; set; }

        [Inject]
        public ITripClient TripClient { get; set; }

        [Inject]
        public CalculationHelper CalculationHelper { get; set; }

        private List<Models.Trip.Trip> _trips;

        private bool _loadingPage;
        private bool _openTripDialog;
        private bool _openCalculationDialog;
        private string _tripDialogTitle;

        private List<CalculateBabyTripResponse> _calculations = new();

        private Models.Trip.Trip? _selectedTrip;

        protected override async Task OnParametersSetAsync()
        {
            _loadingPage = true;

            await GetTripsAsync();

            _loadingPage = false;
        }

        private async Task GetTripsAsync()
        {
            var trips = await TripClient.GetAllAsync();

            _trips =
                trips
                .Select(t => new Models.Trip.Trip
                {
                    Id = t.Id,
                    Name = t.Name,
                    Start = t.Start.Date,
                    End = t.End.Date
                })
                .Where(t => t.End > DateTime.Today)
                .OrderBy(t => t.Start)
                .ToList();
        }

        private async Task RefreshAsync()
        {
            await GetTripsAsync();

            StateHasChanged();
        }

        private async Task OnDeleteAsync(Models.Trip.Trip trip)
        {
            _loadingPage = true;

            await TripClient.DeleteAsync(trip.Id);

            _loadingPage = false;

            await RefreshAsync();
        }

        private async Task OnCalculateAsync(Models.Trip.Trip trip)
        {
            _selectedTrip = trip;
            _calculations = await CalculationHelper.GetCalculationsForBabiesAsync(_selectedTrip);
            _openCalculationDialog = true;
        }

        private void OnOpenEditDialog(Models.Trip.Trip trip)
        {
            _openTripDialog = true;
            _tripDialogTitle = "Edit Trip";
            _selectedTrip = trip;
        }

        private void OnOpenAddDialog()
        {
            _openTripDialog = true;
            _tripDialogTitle = "Add Trip";
            _selectedTrip = new();
        }

        private async void OnCloseTripDialog()
        {
            _openTripDialog = false;

            await RefreshAsync();
        }
    }
}
