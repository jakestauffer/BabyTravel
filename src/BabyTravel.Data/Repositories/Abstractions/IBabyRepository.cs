using BabyTravel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Data.Repositories.Abstractions
{
    public interface IBabyRepository : IRepository<Baby>
    {
        public Task<List<Baby>> GetBabiesByUserAsync(string email);
    }
}
