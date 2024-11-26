using System.ComponentModel.DataAnnotations;
using BabyTravel.Api.Models.Shared;

namespace BabyTravel.Api.Models.Calculate.Sleep
{
    public class CalculateSleepRequest : IWithBabyBirthday
    {
        [Required]
        public DateTime BabyBirthday { get; set; }
    }
}
