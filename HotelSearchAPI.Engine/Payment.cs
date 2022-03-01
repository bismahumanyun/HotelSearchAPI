using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSearchAPI.Engine
{
    public class Payment
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ApiUser))]
        public string customer_id { get; set; }
        public decimal amount_received { get; set; }
        public DateTime amount_received_dte { get; set; }

    }
}
