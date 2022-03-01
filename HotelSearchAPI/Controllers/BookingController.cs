using AutoMapper;
using HotelSearchAPI.Common.DTOs;
using HotelSearchAPI.Common.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HotelSearchAPI.Engine;
using Microsoft.AspNetCore.Authorization;

namespace BookingSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BookingController> _logger;
        private readonly IMapper _mapper;

        public BookingController(IUnitOfWork unitOfWork, ILogger<BookingController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }        

        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("", Name = "CreateBooking")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDTO BookingDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateBooking)}");
                return BadRequest(ModelState);
            }
             
            var Booking = _mapper.Map<Booking>(BookingDTO);            
            await _unitOfWork.Bookings.Insert(Booking);
            await _unitOfWork.Save();

            return CreatedAtRoute("CreateBooking", new { id = Booking.Id }, Booking);
        }        
        
    }
}
