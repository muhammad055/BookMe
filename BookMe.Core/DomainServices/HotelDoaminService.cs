﻿using BookMe.Core.DomainModels;
using BookMe.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookMe.Contract.Dtos;

namespace BookMe.Core.DomainServices
{
    public class HotelDoaminService : IHotelDomainService
    {

        public BookMeContext _bookMeContext { get; set; }
        public HotelDoaminService(BookMeContext bookMeContext)
        {
            _bookMeContext = bookMeContext;
        }


        public async  Task<List<Hotel>> GetHotelsByName(string Name)
        {

           var res =from name in _bookMeContext.Hotels where EF.Functions.FreeText(name.Name, Name) select name;
           return await res.ToListAsync();
        }

        public async Task<Hotel> GetHotelsById(int Id)
        {
            return await _bookMeContext.Hotels.Where(h => h.Id == Id)
                                        .Include(f => f.HotelFacilities)
                                        .Include(r => r.Ratings)
                                        .FirstOrDefaultAsync();
        }

        public async Task<List<AvailableRooms>> GetAvailableRooms(AvailableRoomsRequestDto availableRoomsRequestDto)
        {
            var res = _bookMeContext.Set<AvailableRooms>().Where(x=>x.HotelId>0);
            if (availableRoomsRequestDto.HotelId > 0)
            {
                res = res.Where(x => x.HotelId == availableRoomsRequestDto.HotelId);
            }
            if (availableRoomsRequestDto.CheckInDate != null)
            {
                res = res.Where(x => x.CheckOutDate <= availableRoomsRequestDto.CheckInDate);
            }
            
            return await res.ToListAsync();
        }


    }
}
