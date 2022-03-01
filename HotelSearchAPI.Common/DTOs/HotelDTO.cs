using System;
using System.ComponentModel.DataAnnotations;

namespace HotelSearchAPI.Common.DTOs
{
    public class CreateHotelDTO
    {
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Hotel Name is too lengthy")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 200, ErrorMessage = "Address Name  is too lengthy")]
        public string Address { get; set; }        
        public int no_of_rooms { get; set; }

        [Required]
        [Range(1, 5)]
        public decimal Ratings { get; set; }
        public DateTime execution_dte { get; set; }
    }

    public class HotelDTO : CreateHotelDTO
    {
        public int Id { get; set; }
        
    }



}
