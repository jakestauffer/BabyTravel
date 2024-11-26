using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Api.Exceptions
{
    public class OneTravelDateSpecifiedException : ValidationException
    {
        public OneTravelDateSpecifiedException() : base("Only one travel date was specified. Must specify both or neither.")
        {
        }
    }
}
