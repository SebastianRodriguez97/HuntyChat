using System;

namespace Hunty.Chat.Transverse.Models.Request.Customer
{
    public class CreateCustomerRequest
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int IdCity { get; set; }
        public string DocumentTypeCode { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}
