using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSearchAPI.Engine
{
    public class Booking 
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ApiUser))]
 	    public string customer_id { get; set; }

        [ForeignKey(nameof(Room))]
        public int room_id { get; set; }
        public DateTime booking_date { get; set; }
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; set; }

    }
}
