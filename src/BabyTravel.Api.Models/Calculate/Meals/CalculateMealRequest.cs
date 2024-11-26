using System.ComponentModel.DataAnnotations;
using BabyTravel.Api.Models.Calculate.Abstractions;
using BabyTravel.Api.Models.Shared;

namespace BabyTravel.Api.Models.Calculate.Meals
{
    public class CalculateMealRequest : IWithBabyBirthday, IWithTravelDates
    {
        [Required]
        public DateTime BabyBirthday { get; set; }

        public DateTime? TravelStartDate { get; set; }

        public DateTime? TravelEndDate { get; set; }
    }
}
