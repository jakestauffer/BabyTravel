using BabyTravel.UI.Client.Models.Baby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.UI.Client.Models.Calculate.Responses
{
    public  class CalculateBabyTripResponse
    {
        public Models.Baby.Baby Baby { get; set; }

        public CalculateTripResponse CalculateTripResponse { get; set; }
    }
}
