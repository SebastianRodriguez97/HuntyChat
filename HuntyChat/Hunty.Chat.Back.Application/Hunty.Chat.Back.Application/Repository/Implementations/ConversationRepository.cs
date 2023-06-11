using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hunty.Chat.Back.Database.Context;
using Hunty.Chat.Back.Database.Entities;
using Hunty.Chat.Back.Database.Repository;

namespace Hunty.Chat.Back.Application.Repository.Implementations
{
    public class ConversationRepository : BaseRepository<Conversations, TPContext>
    {
        private readonly TPContext _context;

        public ConversationRepository(TPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Conversations> GetLastConversationByUserCode(string code)
        {
            IEnumerable<Conversations> user = await GetFilteredAsync(x => x.User.Uid == code);
            return user.ToList().FirstOrDefault();
        }

        public async Task<bool> AddUser(string idRoom, string idUser)
        {
            Conversations conversation = await AddAsync(
                new Conversations() { 
                    Id_User = int.Parse(idUser),
                    Id_Room = int.Parse(idRoom)
                });
            return conversation != null;
        }
    }
}
