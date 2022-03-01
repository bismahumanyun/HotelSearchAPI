using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSearchAPI.Engine
{
    public class Room
    {
        public int Id { get; set; }
        public int room_no { get; set; }
        public decimal price_per_day { get; set; }
        public char is_available_status { get; set; }

        [ForeignKey(nameof(Hotel))]
        public int hotelId { get; set; }
        public DateTime execution_dte { get; set; }
    }
}
