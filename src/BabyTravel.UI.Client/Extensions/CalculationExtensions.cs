using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Models.Calculate.Responses;

namespace BabyTravel.UI.Client.Extensions
{
    public static class CalculationExtensions
    {
        public static CalculateBabyTripResponse Summarize(this List<CalculateBabyTripResponse> calculateBabyTripResponses) =>
            new CalculateBabyTripResponse()
            {
                Baby = new()
                {
                    Name = "All babies"
                },
                    CalculateTripResponse = new()
                    {
                        DiaperResponse = calculateBabyTripResponses.Select(c => c.CalculateTripResponse.DiaperResponse).Aggregate(new Api.Client.CalculateDiaperResponse(), (acu, next) =>
                        {
                            acu.DiapersPerDay += next.DiapersPerDay;
                            acu.TotalDiapers += next.TotalDiapers;

                            return acu;
                        }),
                        MealResponse = calculateBabyTripResponses.Select(c => c.CalculateTripResponse.MealResponse).Aggregate(new Api.Client.CalculateMealResponse(), (acu, next) =>
                        {
                            acu.TotalMeals = AddRanges(acu.TotalMeals, next.TotalMeals);
                            acu.MealsPerDay = AddRanges(acu.MealsPerDay, next.MealsPerDay);

                            acu.TotalSnacks = AddRanges(acu.TotalSnacks, next.TotalSnacks);
                            acu.SnacksPerDay = AddRanges(acu.SnacksPerDay, next.SnacksPerDay);

                            acu.TotalSolids = AddRanges(acu.TotalSolids, next.TotalSolids);
                            acu.SolidsPerDay = AddRanges(acu.SolidsPerDay, next.SolidsPerDay);

                            acu.TotalFeedings = AddRanges(acu.TotalFeedings, next.TotalFeedings);
                            acu.FeedingsPerDay = AddRanges(acu.FeedingsPerDay, next.FeedingsPerDay);

                            return acu;
                        }),
                        OutfitResponse = calculateBabyTripResponses.Select(c => c.CalculateTripResponse.OutfitResponse).Aggregate(new Api.Client.CalculateOutfitResponse(), (acu, next) =>
                        {
                            acu.TotalOutfits += next.TotalOutfits;
                            acu.OutfitsPerDay += next.OutfitsPerDay;
                            acu.TotalSleepsacks += next.TotalSleepsacks;
                            acu.TotalSocks += next.TotalSocks;
                            acu.TotalTops += next.TotalTops;
                            acu.TotalBottoms += next.TotalBottoms;
                            acu.TotalHats += next.TotalHats;
                            acu.TotalPajamas += next.TotalPajamas;

                            return acu;
                        }),
                        SleepResponse = null
                    }
                };

        private static IntRange AddRanges(IntRange? range1, IntRange? range2) =>
           new IntRange()
           {
               Min = (range1?.Min ?? 0) + (range2?.Min ?? 0),
               Max = (range1?.Max ?? 0) + (range2?.Max ?? 0)
           };

        private static DecimalRange AddRanges(DecimalRange? range1, DecimalRange? range2) =>
           new DecimalRange()
           {
               Min = (range1?.Min ?? 0) + (range2?.Min ?? 0),
               Max = (range1?.Max ?? 0) + (range2?.Max ?? 0)
           };
    }
}
