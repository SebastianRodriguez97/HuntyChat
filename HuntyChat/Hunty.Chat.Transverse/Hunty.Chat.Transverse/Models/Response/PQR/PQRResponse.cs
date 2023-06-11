using System;

namespace Hunty.Chat.Transverse.Models.Response.PQR
{
    public class PQRResponse
    {
        public Guid Identifier { get; set; }
        public DateTime CreationDate { get; set; }
        public int IdCustomer { get; set; }
        public string FullNameCustomer { get; set; }
        public string PQRTypeCode { get; set; }
        public string PQRTypeName { get; set; }
        public string Comment { get; set; }
    }
}
