using BookMe.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BookMe.Contract.Dtos;

namespace BookMe.Application.MappingProfiles
{
    public class HotelReqResProfile :Profile
    {
        public HotelReqResProfile()
        {
            CreateMap<AvailableRooms, AvailableRoomsDto>();
            CreateMap<AvailableRoomsDto , AvailableRooms> ();
        }
      
    }
}
