using BabyTravel.Calculator.Models;
using BabyTravel.Utilities;
using CSharpFunctionalExtensions;
using System.Diagnostics;

namespace BabyTravel.Calculator
{
    public class Meals
    {
        private Baby _baby;

        private Travel _travel;

        private Meals(Baby baby)
        {
            _baby = baby;
        }

        private Meals(Baby baby, Travel travel)
        {
            _baby = baby;
            _travel = travel;
        }

        public static Meals For(Baby baby) => new(baby, Travel.Today);

        public Meals Traveling(Travel travel) => new(_baby, travel);

        public Range FeedingsPerDay => _baby.AgeInMonths switch
        {
            <= 1 and <= 2 => new Range(8, 8),
            >= 3 and <= 6 => new Range(6, 8),
            >= 6 and <= 8 => new Range(4, 6),
            >= 9 and <= 12 => new Range(3, 5),
            _ => new Range(0, 0)
        };

        public Range SolidsPerDay => _baby.AgeInMonths switch
        {
            < 6 => new Range(0, 0),
            >= 6 and <= 9 => new Range(1, 2),
            _ => new Range(3, 3)
        };

        public Range SnacksPerDay => _baby.AgeInMonths switch
        {
            < 12 => new Range(0, 0),
            _ => new Range(2, 2)
        };

        public Range MealsPerDay => FeedingsPerDay.Union(SolidsPerDay);

        public Range TotalSnacks => SnacksPerDay.Multiply(_travel.Days);

        public Range TotalFeedings => FeedingsPerDay.Multiply(_travel.Days);

        public Range TotalSolids => SolidsPerDay.Multiply(_travel.Days);

        public Range TotalMeals => MealsPerDay.Multiply(_travel.Days);
    }
}
