using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hunty.Chat.Back.Database.Context;
using Hunty.Chat.Back.Database.Entities;
using Hunty.Chat.Back.Database.Repository;

namespace Hunty.Chat.Back.Application.Repository.Implementations
{
    public class RoomRepository : BaseRepository<Rooms, TPContext>
    {
        private readonly TPContext _context;

        public RoomRepository(TPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Rooms> GetByCodeAsync(string code)
        {
            IEnumerable<Rooms> room = await GetFilteredAsync(x => x.Uid == code);
            return room.FirstOrDefault();
        }

        public async Task<Rooms> GetActiveAsync()
        {
            IEnumerable<Rooms> room = await GetAllAsync();
            return room.LastOrDefault();
        }
    }
}
