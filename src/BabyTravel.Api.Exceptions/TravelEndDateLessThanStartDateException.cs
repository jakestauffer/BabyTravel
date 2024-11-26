using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Api.Exceptions
{
    public class TravelEndDateLessThanStartDateException : ValidationException
    {
        public TravelEndDateLessThanStartDateException() : base("Travel days must be greater than or equal to 0.")
        {
        }
    }
}
