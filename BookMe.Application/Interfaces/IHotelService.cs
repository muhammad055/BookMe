using BookMe.Contract.Dtos;
using BookMe.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookMe.Application.Interfaces
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetHotelsByName(string Name);
        Task<List<AvailableRoomsDto>> GetAvailableRooms(AvailableRoomsRequestDto availableRoomsRequestDto);
    }
}
