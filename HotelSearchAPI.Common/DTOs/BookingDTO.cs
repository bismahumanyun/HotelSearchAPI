using System;

namespace HotelSearchAPI.Common.DTOs
{
    public class CreateBookingDTO
    {
        public string customer_id { get; set; }
        public int room_id { get; set; }
        public DateTime booking_date { get; set; }
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; set; }

    }

    public class BookingDTO : CreateBookingDTO
    {
        public int Id { get; set; }
        
    }



}
