using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Models.Calculate.Responses;
using BabyTravel.UI.Client.Models.Trip;

namespace BabyTravel.UI.Client.Helpers
{
    public class CalculationHelper
    {
        private readonly IBabyClient _babyClient;
        private readonly ITripClient _tripClient;
        private readonly ICalculateClient _calculateClient;

        public CalculationHelper(IBabyClient babyClient, ITripClient tripClient, ICalculateClient calculateClient) 
        {
            _babyClient = babyClient;
            _tripClient = tripClient;
            _calculateClient = calculateClient;
        }

        public async Task<List<CalculateBabyTripResponse>> GetCalculationsForBabiesAsync(Trip trip)
        {
            var babies = await _babyClient.GetAllAsync();

            var calculations = new List<CalculateBabyTripResponse>();
            foreach (var b in babies)
            {
                calculations.Add(
                    new CalculateBabyTripResponse()
                    {
                        Baby = new()
                        {
                            Birthday = b.BabyBirthday.Date,
                            Name = b.Name,
                            Id = b.Id,
                        },
                        CalculateTripResponse = new()
                        {
                            DiaperResponse = await _calculateClient.DiapersAsync(new()
                            {
                                BabyBirthday = b.BabyBirthday,
                                TravelStartDate = trip.Start.Date,
                                TravelEndDate = trip.End.Date
                            }),
                            MealResponse = await _calculateClient.MealsAsync(new()
                            {
                                BabyBirthday = b.BabyBirthday,
                                TravelStartDate = trip.Start.Date,
                                TravelEndDate = trip.End.Date
                            }),
                            OutfitResponse = await _calculateClient.OutfitsAsync(new()
                            {
                                BabyBirthday = b.BabyBirthday,
                                TravelStartDate = trip.Start.Date,
                                TravelEndDate = trip.End.Date
                            }),
                            SleepResponse = await _calculateClient.SleepAsync(new()
                            {
                                BabyBirthday = b.BabyBirthday
                            })
                        }
                    });
            }

            return calculations;
        }
    }
}
