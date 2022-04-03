using AutoMapper;
using BookMe.Application.MappingProfiles;
using BookMe.Application.Services;
using BookMe.Tests.Setup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace BookMe.Tests.UnitTests.ApplicationServices
{
    public class HotelServiceTests : IClassFixture<HotelDataFixture>
    {
        private readonly HotelDataFixture _hotelDataFixture;
        public HotelServiceTests(HotelDataFixture hotelDataFixture)
        {
            _hotelDataFixture = hotelDataFixture;
        }

        private HotelService GetServiceInstance()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new HotelReqResProfile());
            });
            var mapper = mockMapper.CreateMapper();
            var hotelService = new HotelService(_hotelDataFixture.HotelDomainService, mapper);
            return hotelService;
        }
        [Fact]
        public async Task GetHotelsByNameValidName_ReturnsHotel()
        {
            var hotelService = GetServiceInstance();
            string name = "Burj";
            var hotel = await hotelService.GetHotelsByName(name);
            hotel.ShouldNotBe(null);
        }
        [Fact]
        public async Task GetHotelsByNameInValidName_ReturnsNull()
        {
            var hotelService = GetServiceInstance();
            string name = "abcd";
            var hotel = await hotelService.GetHotelsByName(name);
            hotel.ShouldBe(null);
        }
    }
}
