using BabyTravel.Data.Contexts;
using BabyTravel.Data.Models;
using BabyTravel.Data.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BabyTravelDbContext context) : base(context)
        {
        }
    }
}
