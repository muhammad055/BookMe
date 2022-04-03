using BookMe.Contract.Dtos;
using BookMe.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookMe.Core.Interfaces
{
    public interface IHotelDomainService
    {
        Task<List<Hotel>> GetHotelsByName(string Name);
        Task<Hotel> GetHotelsById(int Id);
        Task<List<AvailableRooms>> GetAvailableRooms(AvailableRoomsRequestDto availableRoomsRequestDto);
        Task<int> MakeBooking(BookingRequestDto bookingRequestDto);
    }
}
