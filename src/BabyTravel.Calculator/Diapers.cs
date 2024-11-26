using BabyTravel.Calculator.Models;
using BabyTravel.Utilities;
using CSharpFunctionalExtensions;
using System.Diagnostics;

namespace BabyTravel.Calculator
{
    public class Diapers
    {
        private Baby _baby;
        private Travel _travel;

        private Diapers(Baby baby, Travel travel)
        {
            _baby = baby;
            _travel = travel;
        }

        public static Diapers For(Baby baby) => new(baby, Travel.Today);

        public Diapers Traveling(Travel travel) => new(_baby, travel);

        public int DiapersPerDay => _baby.AgeInMonths switch
        {
            < 1 => 12,
            >= 1 and < 5 => 10,
            >= 5 and <= 8 => 9,
            >= 9 and < 18 => 7,
            _ => 5
        };

        public int TotalDiapers => DiapersPerDay * _travel.Days;
    }
}
