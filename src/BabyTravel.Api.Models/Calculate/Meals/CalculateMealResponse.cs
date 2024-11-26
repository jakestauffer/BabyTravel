using BabyTravel.Calculator.Models;

namespace BabyTravel.Api.Models.Calculate.Meals
{
    public class CalculateMealResponse
    {
        public IntRange TotalMeals { get; set; }

        public IntRange TotalSnacks { get; set; }

        public IntRange TotalFeedings { get; set; }

        public IntRange TotalSolids { get; set; }

        public IntRange SolidsPerDay { get; set; }

        public IntRange FeedingsPerDay { get; set; }

        public IntRange MealsPerDay { get; set; }

        public IntRange SnacksPerDay { get; set; }
    }
}
