using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Api.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message, System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
