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
    public class BabyRepository : Repository<Baby>, IBabyRepository
    {
        private readonly IUserRepository _userRepository;

        public BabyRepository(BabyTravelDbContext context, IUserRepository userRepository) : base(context)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Baby>> GetBabiesByUserAsync(string email)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Email == email);

            return await Entity.Where(x => x.UserId == user.Id).ToListAsync();
        }
    }
}
