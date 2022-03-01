using System;
using System.ComponentModel.DataAnnotations;

namespace HotelSearchAPI.Common.DTOs
{
    public class CreateRoomDTO
    { 

        [Required]         
        public int room_no { get; set; }

        [Required]
        public DateTime check_in_date { get; set; }

        [Required]         
        public DateTime check_out_date { get; set; }

        public char is_available_status { get; set; }
        
        [Required]
        public int hotelId { get; set; }

        public DateTime execution_dte { get; set; }
    }     
    public class RoomDTO : CreateRoomDTO
    {
        public int Id { get; set; }

    }



}
