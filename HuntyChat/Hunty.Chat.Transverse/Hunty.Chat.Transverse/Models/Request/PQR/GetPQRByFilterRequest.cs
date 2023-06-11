using System;

namespace Hunty.Chat.Transverse.Models.Request.PQR
{
    public class GetPQRByFilterRequest
    {
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public int? IdCity { get; set; }
        public string DocumentNumber { get; set; }
    }
}
