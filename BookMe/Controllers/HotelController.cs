using BookMe.Application.Interfaces;
using BookMe.Contract.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookMe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Get all the hotels that matches the name parameter
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("GetHotelByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<System.Collections.Generic.List<Core.DomainModels.Hotel>> GetHotelsByName(string name)
        {
            return await _hotelService.GetHotelsByName(name);
        }

        /// <summary>
        /// Contains parameters like HotelId and checkIn date to get the available rooms.
        /// </summary>
        /// <param name="availableRoomsRequestDto"></param>
        /// <returns></returns>
        [HttpGet("GetAvailableRooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<AvailableRoomsDto>> GetAvailableRooms([FromQuery] AvailableRoomsRequestDto availableRoomsRequestDto)
        {
            return await _hotelService.GetAvailableRooms(availableRoomsRequestDto);
        }
    }
}
