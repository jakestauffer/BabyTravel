using BabyTravel.Api.Exceptions;
using BabyTravel.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Calculator.Models
{
    public class Baby
    {
        public int AgeInMonths { get; private set; }

        public static Baby WithBirthday(DateTime birthday)
        {
            return new()
            {
                AgeInMonths = birthday.MonthsFromToday(),
            };
        }
    }
}
