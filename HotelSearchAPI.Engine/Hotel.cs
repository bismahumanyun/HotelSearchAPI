using System;

namespace HotelSearchAPI.Engine
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int no_of_rooms { get; set; }
        public decimal Ratings { get; set; }
        public DateTime execution_dte { get; set; }

    }
}
