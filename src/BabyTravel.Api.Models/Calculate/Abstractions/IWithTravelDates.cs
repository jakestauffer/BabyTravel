using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Api.Models.Calculate.Abstractions
{
    public interface IWithTravelDates
    {
        public DateTime? TravelStartDate { get; set; }
        public DateTime? TravelEndDate { get; set; }
    }
}
