namespace Hunty.Chat.Transverse.Models.Request.Customer
{
    public class UpdateCustomerRequest
    {
        public long IdCustomer { get; set; }
        public string PhoneNumber { get; set; }
        public int IdCity { get; set; }
    }
}
