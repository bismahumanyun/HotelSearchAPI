using AutoMapper;
using HotelSearchAPI.Common.DTOs;
using HotelSearchAPI.Engine;

namespace HotelSearchAPI.Common.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
             
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();

            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Room, CreateRoomDTO>().ReverseMap();

            CreateMap<Booking, BookingDTO>().ReverseMap();
            CreateMap<Booking, CreateBookingDTO>().ReverseMap(); 

            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<Payment, CreatePaymentDTO>().ReverseMap();

            CreateMap<ApiUser, UserDTO>().ReverseMap();
        }
    }
}
