using BookMe.Core.DomainModels;
using BookMe.Tests.Utils;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BookMe.Application.Interfaces;
using BookMe.Core.Interfaces;
using BookMe.Contract.Dtos;
using System.Threading.Tasks;

namespace BookMe.Tests.Setup
{
    public class HotelDataFixture
    {
        public BookMeContext DbContext
        {
            get
            {
                var hotelList = DbSetMockHelper.GetMockDbSetAsync(HotelList.ToList());
                var dbContextMock = new Mock<BookMeContext>();
                dbContextMock.Setup(e => e.Set<Hotel>()).Returns(hotelList.Object);
                return dbContextMock.Object;
            }
        }

        public IEnumerable<Hotel> HotelList
        {
            get
            {
                yield return new Hotel
                {
                    CityId = 1,
                    Id = 1,
                    Location = "Diera",
                    Name = "Burj Hotel",

                };
                yield return new Hotel
                {
                    CityId = 1,
                    Id = 2,
                    Location = "Al Barsha",
                    Name = "NovoT Hotel",

                };
            }
        }
        public IEnumerable<AvailableRoomsDto> AvailableRoomsList
        {
            get
            {
                yield return new AvailableRoomsDto
                {
                    CheckInDate = DateTime.Now,
                    HotelId = 1,
                    Name = "InterContinental",
                    RoomId = 1,
                    RoomNumber = 101,
                };
                yield return new AvailableRoomsDto
                {
                    CheckInDate = DateTime.Now,
                    HotelId = 1,
                    Name = "Imperial In",
                    RoomId = 4,
                    RoomNumber = 104,
                };
            }
        }
        public IHotelService IHotelService
        {
            get
            {
                var hotelServiceMock = new Mock<IHotelService>();
                hotelServiceMock.Setup(e => e.GetAvailableRooms(It.IsAny<AvailableRoomsRequestDto>())).ReturnsAsync(AvailableRoomsList.ToList());
                hotelServiceMock.Setup(e => e.GetHotelsByName(It.IsAny<string>())).ReturnsAsync(HotelList.ToList());
                return hotelServiceMock.Object;
            }
        }

        public IHotelDomainService HotelDomainService
        {
            get
            {
                var hotelDomainServiceMock = new Mock<IHotelDomainService>();
                hotelDomainServiceMock.Setup(e => e.GetAvailableRooms(It.IsAny<AvailableRoomsRequestDto>())).ReturnsAsync(new List<AvailableRooms>());
                hotelDomainServiceMock.Setup(e => e.GetHotelsByName("Burj")).ReturnsAsync(HotelList.ToList());
                return hotelDomainServiceMock.Object;
            }
        }

    }
}
