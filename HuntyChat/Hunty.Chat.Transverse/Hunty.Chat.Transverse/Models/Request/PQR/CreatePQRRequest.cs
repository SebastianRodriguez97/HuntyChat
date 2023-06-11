namespace Hunty.Chat.Transverse.Models.Request.PQR
{
    public class CreatePQRRequest
    {
        public string Comment { get; set; }
        public long IdCustomer { get; set; }
        public string PQRTypeCode { get; set; }
    }
}
