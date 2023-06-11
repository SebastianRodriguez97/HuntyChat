using System;

namespace Hunty.Chat.Transverse.Models.Response.Customer
{
    public class CustomerResponse
    {
        public long IdCustomer { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public int IdCity { get; set; }
        public string CityName { get; set; }
        public string DocumentTypeCode { get; set; }
        public string DocumentTypeName { get; set; }
    }
}
