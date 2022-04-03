
using AutoMapper;
using BookMe.Application.Interfaces;
using BookMe.Contract.Dtos;
using BookMe.Core.DomainModels;
using BookMe.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BookMe.Application.Services
{
    public class HotelService : IHotelService
    {
        public HotelService(IHotelDomainService hotelDomainService,
                            IMapper mapper)
        {
            _hotelDomainService = hotelDomainService;
            _mapper = mapper;   
        }
        private readonly IMapper _mapper;
        private readonly IHotelDomainService _hotelDomainService;

        public async Task<List<Hotel>> GetHotelsByName(string Name)
        {
            var res = await _hotelDomainService.GetHotelsByName(Name);
            return res;
        }
        public async Task<List<AvailableRoomsDto>> GetAvailableRooms(AvailableRoomsRequestDto availableRoomsRequestDto)
        {
            var res = await _hotelDomainService.GetAvailableRooms(availableRoomsRequestDto);
            return _mapper.Map<List<AvailableRoomsDto>>(res);
        }
        public async Task<int> MakeBooking(BookingRequestDto bookingRequestDto)
        {
            if (bookingRequestDto.RoomRent.Any(x => x.RoomId == 0 || x.Amount == 0))
            {
                throw new Exception("Please provide Rooms and amount details.");
            }
            return await _hotelDomainService.MakeBooking(bookingRequestDto);
            
        }
    }
}