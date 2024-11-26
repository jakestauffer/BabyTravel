using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Api.Models.Calculate.Outfits
{
    public class CalculateOutfitResponse
    {
        public int TotalOutfits { get; set; }
        public int OutfitsPerDay { get; set; }
        public int TotalTops { get; set; }
        public int TotalBottoms { get; set; }
        public int TotalHats { get; set; }
        public int TotalSocks { get; set; }
        public int TotalPajamas { get; set; }
        public int TotalSleepsacks { get; set; }
    }
}
