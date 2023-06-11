using System;

namespace Hunty.Chat.Transverse.Models.Request.Customer
{
    public class CustomerByFilterRequest
    {
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public int? IdCity { get; set; }
        public string DocumentNumber { get; set; }
    }
}
