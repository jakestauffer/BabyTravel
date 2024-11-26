using BabyTravel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Data.Repositories.Abstractions
{
    public interface ITripRepository : IRepository<Trip>
    {
        public Task<List<Trip>> GetTripsByUserAsync(string email);
    }
}
