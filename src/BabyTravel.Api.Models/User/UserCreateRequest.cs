using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Api.Models.User
{
    public class UserCreateRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
