using BabyTravel.Calculator.Models;
using BabyTravel.Utilities;
using CSharpFunctionalExtensions;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace BabyTravel.Calculator
{
    public class Outfits
    {
        private Baby _baby;
        private Travel _travel;
        private int _washingFrequencyInDays;
        private int _outfitBufferPerDay;

        private Outfits(Baby baby, Travel travel, int washFrequencyInDays, int outfitBufferPerDay)
        {
            _baby = baby;
            _travel = travel;
            _washingFrequencyInDays = washFrequencyInDays;
            _outfitBufferPerDay = outfitBufferPerDay;
        }

        public static Outfits For(Baby baby) => new(baby, Travel.Today, 0, Constants.Outfit.StandardBuffer);

        public Outfits WashEvery(int? days) =>
            !days.HasValue || days.Value < 0
            ? new(_baby, _travel, 0, _outfitBufferPerDay)
            : new(_baby, _travel, days.Value, _outfitBufferPerDay);

        public Outfits Traveling(Travel travel) => new(_baby, travel, _washingFrequencyInDays, _outfitBufferPerDay);

        public int OutfitsPerDay => _baby.AgeInMonths switch
        {
            < 1 => 4,
            _ => 2
        } + _outfitBufferPerDay;

        public int OutfitBufferPerDay => _outfitBufferPerDay;
        public int TotalOutfits => OutfitsPerDay * _days;
        public int TotalTops => OutfitsPerDay * _days;
        public int TotalBottoms => OutfitsPerDay * _days;
        public int TotalSocks => OutfitsPerDay * _days;
        public int TotalPajamas => _days;
        public int TotalHats => (int)Math.Ceiling((decimal)_days / 2);
        public int TotalSleepsacks => (int)Math.Ceiling((decimal)_days / 2);
        private int _days => _washingFrequencyInDays > 0 ? _washingFrequencyInDays : _travel.Days;
    }
}
