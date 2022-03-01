using System;

namespace HotelSearchAPI.Common.DTOs
{
    public class CreatePaymentDTO
    {
        public string customer_id { get; set; }
        public decimal amount_received { get; set; }
        public DateTime amount_received_dte { get; set; }

    }

     public class PaymentDTO : CreatePaymentDTO
    {
        public int Id { get; set; }

    }



}
