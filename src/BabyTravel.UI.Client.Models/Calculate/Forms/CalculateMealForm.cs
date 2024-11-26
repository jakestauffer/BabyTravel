using System.ComponentModel.DataAnnotations;

namespace BabyTravel.UI.Client.Models.Calculate.Forms
{
    public class CalculateMealForm : IWithBabyBirthday, IWithTravelDates
    {
        [Required]
        public DateTime BabyBirthday { get; set; }

        public DateTime? TravelStartDate { get; set; }

        public DateTime? TravelEndDate { get; set; }
    }
}
