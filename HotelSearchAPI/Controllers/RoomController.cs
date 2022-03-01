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

namespace HotelSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RoomController> _logger;
        private readonly IMapper _mapper;

        public RoomController(IUnitOfWork unitOfWork, ILogger<RoomController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRooms([FromQuery] RequestParams requestParams)
        {
            var rooms = await _unitOfWork.Rooms.GetPagedList(requestParams);
            var results = _mapper.Map<IList<RoomDTO>>(rooms);
            return Ok(results);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("", Name = "CreateRoom")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDTO roomDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateRoom)}");
                return BadRequest(ModelState);
            }

            var room = _mapper.Map<Room>(roomDTO);
            await _unitOfWork.Rooms.Insert(room);
            await _unitOfWork.Save();

            return CreatedAtRoute("CreateRoom", new { id = room.Id }, room);
        }
                     
    }
}
