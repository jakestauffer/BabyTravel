using BabyTravel.Data.Contexts;
using BabyTravel.Data.Models;
using BabyTravel.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Data.Repositories
{
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        private readonly IUserRepository _userRepository;

        public TripRepository(BabyTravelDbContext context, IUserRepository userRepository) : base(context)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Trip>> GetTripsByUserAsync(string email)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Email == email);

            return await Entity.Where(x => x.UserId == user.Id).ToListAsync();
        }
    }
}
