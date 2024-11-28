using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyTravel.Data.Models
{
    [Index(nameof(Name), nameof(UserId), IsUnique = true)]
    public class Baby : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
    }
}
