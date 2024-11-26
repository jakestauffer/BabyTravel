using BabyTravel.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Data.Repositories.Abstractions
{
    public interface IUserRepository : IRepository<User>;
}
