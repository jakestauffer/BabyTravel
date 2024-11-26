using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.UI.Client.Models.Calculate.Forms
{
    public class CalculateForm
    {
        public CalculationType CalculationType { get; set; }

        public DateTime BabyBirthday { get; set; }

        public DateTime? TravelStartDate { get; set; }

        public DateTime? TravelEndDate { get; set; }

        public int? WashingFrequencyInDays { get; set; }
    }

    public enum CalculationType
    {
        Meal,
        Sleep,
        Diaper,
        Outfit
    }
}
