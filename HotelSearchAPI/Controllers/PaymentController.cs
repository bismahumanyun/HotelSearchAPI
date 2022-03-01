using AutoMapper;
using HotelSearchAPI.Common.DTOs;
using HotelSearchAPI.Common.IRepository;
using HotelSearchAPI.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelSearchAPI.Engine;

namespace PaymentSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PaymentController> _logger;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork unitOfWork, ILogger<PaymentController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
       
        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("", Name = "CreatePayment")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentDTO PaymentDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreatePayment)}");
                return BadRequest(ModelState);
            }

            var Payment = _mapper.Map<Payment>(PaymentDTO);
            await _unitOfWork.Payments.Insert(Payment);            
            await _unitOfWork.Save();

            return CreatedAtRoute("CreatePayment", new { id = Payment.Id }, Payment);
        }
                
    }
}
