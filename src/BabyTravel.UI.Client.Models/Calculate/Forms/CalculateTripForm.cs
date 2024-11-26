using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.UI.Client.Models.Calculate.Forms
{
    public class CalculateTripForm : IWithBabyBirthday, IWithTravelDates
    {
        [Required]
        public DateTime BabyBirthday { get; set; }

        public DateTime? TravelStartDate { get; set; }

        public DateTime? TravelEndDate { get; set; }

        public int? WashingFrequencyInDays { get; set; }
    }
}