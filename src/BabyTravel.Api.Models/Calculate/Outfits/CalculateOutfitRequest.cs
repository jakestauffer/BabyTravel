using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabyTravel.Api.Models.Calculate.Abstractions;
using BabyTravel.Api.Models.Shared;

namespace BabyTravel.Api.Models.Calculate.Outfits
{
    public class CalculateOutfitRequest : IWithBabyBirthday, IWithTravelDates
    {
        [Required]
        public DateTime BabyBirthday { get; set; }

        public DateTime? TravelStartDate { get; set; }

        public DateTime? TravelEndDate { get; set; }

        public int? WashingFrequencyInDays { get; set; }
    }
}
