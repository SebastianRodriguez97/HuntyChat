using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hunty.Chat.Back.Database.Context;
using Hunty.Chat.Back.Database.Entities;
using Hunty.Chat.Back.Database.Repository;

namespace Hunty.Chat.Back.Application.Repository.Implementations
{
    public class UserRepository : BaseRepository<Users, TPContext>
    {
        private readonly TPContext _context;

        public UserRepository(TPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Users> GetUserByCode(string code)
        {
            IEnumerable<Users> user = await GetFilteredAsync(x => x.Uid == code);
            return user.ToList().FirstOrDefault();
        }

        public async Task<Users> CreateAsync(Users user)
        {
            Users newUser = await AddAsync(user);
            return newUser;
        }

        public async Task<Users> UpdateUserAsync(Users user)
        {
            Users userUpdated = await UpdateAsync(user);
            return userUpdated;
        }
    }
}
