using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Api.Exceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException(string message) : base(message, System.Net.HttpStatusCode.BadRequest)
        {
        }
    }
}
