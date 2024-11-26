using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Models.Baby;
using BabyTravel.UI.Client.Models.Calculate.Responses;
using BabyTravel.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen.Blazor;
using System.Security.Claims;

namespace BabyTravel.UI.Client.Components.Baby
{
    public partial class BabyList
    {
        [CascadingParameter]
        private Task<AuthenticationState>? AuthenticationState { get; set; }

        [Inject]
        public IBabyClient BabyClient { get; set; }

        [Inject]
        public ICalculateClient CalculateClient { get; set; }

        private List<Models.Baby.Baby> _babies;

        private bool _loadingPage;
        private bool _openBabyDialog;
        private bool _openCalculationDialog;
        private string _babyDialogTitle;

        private CalculateTripResponse _calculateTripResponse;

        private Models.Baby.Baby? _selectedBaby;

        protected override async Task OnParametersSetAsync()
        {
            _loadingPage = true;

            await GetBabiesAsync();

            _loadingPage = false;
        }

        private async Task GetBabiesAsync()
        {
            var babies = await BabyClient.GetAllAsync();

            _babies = babies.Select(b => new Models.Baby.Baby
            {
                Id = b.Id,
                Name = b.Name,
                Birthday = b.BabyBirthday.Date
            }).OrderBy(b => b.Birthday).ToList();
        }

        private async Task RefreshAsync()
        {
            await GetBabiesAsync();

            StateHasChanged();
        }

        private async Task OnDeleteAsync(Models.Baby.Baby baby)
        {
            _loadingPage = true;

            await BabyClient.DeleteAsync(baby.Id);

            _loadingPage = false;

            RefreshAsync();
        }

        private async Task OnCalculateAsync(Models.Baby.Baby baby)
        {
            _selectedBaby = baby;

            _calculateTripResponse = new()
            {
                DiaperResponse = await CalculateClient.DiapersAsync(new()
                {
                    BabyBirthday = _selectedBaby.Birthday
                }),
                MealResponse = await CalculateClient.MealsAsync(new()
                {
                    BabyBirthday = _selectedBaby.Birthday
                }),
                OutfitResponse = await CalculateClient.OutfitsAsync(new()
                {
                    BabyBirthday = _selectedBaby.Birthday
                }),
                SleepResponse = await CalculateClient.SleepAsync(new()
                {
                    BabyBirthday = _selectedBaby.Birthday
                })
            };
           
            _openCalculationDialog = true;
        }

        private void OnOpenEditDialog(Models.Baby.Baby baby)
        {
            _openBabyDialog = true;
            _babyDialogTitle = "Edit Baby";
            _selectedBaby = baby;
        }

        private void OnOpenAddDialog()
        {
            _openBabyDialog = true;
            _babyDialogTitle = "Add Baby";
            _selectedBaby = new();
        }

        private string GetAge(Models.Baby.Baby baby)
        {
            var totalMonths = baby.Birthday.MonthsFromToday();
            var years = totalMonths / 12;
            var months = totalMonths % 12;

            return $"{years} year(s) and {months} month(s)";
        }
    }
}
