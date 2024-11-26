using BabyTravel.Api.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Api.Models.Baby
{
    public class BabyCreateRequest : IWithBabyBirthday
    {
        public string Name { get; set; }

        public DateTime BabyBirthday { get; set; }
    }
}
