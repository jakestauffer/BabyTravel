using System.ComponentModel.DataAnnotations;

namespace BabyTravel.UI.Client.Models.Calculate.Forms
{
    public class CalculateSleepForm : IWithBabyBirthday
    {
        [Required]
        public DateTime BabyBirthday { get; set; }
    }
}
