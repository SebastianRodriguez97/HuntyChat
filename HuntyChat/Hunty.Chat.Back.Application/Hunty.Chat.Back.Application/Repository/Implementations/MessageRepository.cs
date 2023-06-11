using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hunty.Chat.Back.Database.Context;
using Hunty.Chat.Back.Database.Entities;
using Hunty.Chat.Back.Database.Repository;

namespace Hunty.Chat.Back.Application.Repository.Implementations
{
    public class MessageRepository : BaseRepository<Messages, TPContext>
    {
        private readonly TPContext _context;

        public MessageRepository(TPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Messages>> GetAllMessagesFromWebhookAsync()
        {
            IEnumerable<Messages> messages = await GetFilteredAsync(x => x.IsFromWebhook);
            return messages.ToList();
        }

        public async Task<Messages> GetByIdAsync(int id)
        {
            IEnumerable<Messages> messages = await GetFilteredAsync(x => x.Id == id);
            return messages?.FirstOrDefault();
        }
    }
}
