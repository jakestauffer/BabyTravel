using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.UI.Client.Models.Calculate.Forms
{
    public interface IWithTravelDates
    {
        public DateTime? TravelStartDate { get; set; }
        public DateTime? TravelEndDate { get; set; }
    }
}
