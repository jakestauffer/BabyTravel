using BabyTravel.Api.Exceptions;
using BabyTravel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Calculator.Models
{
    public class Travel
    {
        public int Days { get; private set; }

        public static Travel Between(DateTime? startTravel, DateTime? endTravel)
        {
            if (!startTravel.HasValue && !endTravel.HasValue)
            {
                return Today;
            }

            if (!startTravel.HasValue || !endTravel.HasValue)
            {
                throw new OneTravelDateSpecifiedException();
            }

            var daysInTravel = endTravel.Value.DaysFrom(startTravel.Value);

            if (daysInTravel < 0)
            {
                throw new TravelEndDateLessThanStartDateException();
            }

            return new()
            {
                Days = daysInTravel + 1
            };
        }

        public static Travel Today => new()
        {
            Days = 1
        };
    }
}
