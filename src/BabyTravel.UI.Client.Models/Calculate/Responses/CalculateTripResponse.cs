using BabyTravel.Api.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.UI.Client.Models.Calculate.Responses
{
    public class CalculateTripResponse
    {
        public CalculateDiaperResponse DiaperResponse { get; set; }
        public CalculateMealResponse MealResponse { get; set; }
        public CalculateOutfitResponse OutfitResponse { get; set; }
        public CalculateSleepResponse SleepResponse { get; set; }
    }
}
