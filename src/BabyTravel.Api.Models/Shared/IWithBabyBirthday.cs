using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Api.Models.Shared
{
    public interface IWithBabyBirthday
    {
        public DateTime BabyBirthday { get; set; }
    }
}
