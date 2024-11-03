using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Data.Migrations;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ShopTARgv23.RealEstateTest
{
    public class RealestateTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
        {
            //Arrange

            RealEstateDto dto = new();

            dto.Location = "asd";
            dto.Size = 123;
            dto.RoomNumber = 123;
            dto.BuildingType = "asd";
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            //Act
            var result = await Svc<IRealEstateServices>().Create(dto);


            //Assert
            Assert.NotNull(result);

        }

        [Fact]
        public async Task ShouldNot_GetByIdRealestate_WhenReturnsNotEqual()
        {
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("58b815d8-284c-425a-8875-d74108e0cda5");

            await Svc <IRealEstateServices>().GetAsync(guid);

            Assert.NotEqual(wrongGuid, guid);
        }

        [Fact]

        public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
        {
            Guid correctGuid = Guid.Parse("58b815d8-284c-425a-8875-d74108e0cda5");
            Guid guid = Guid.Parse("58b815d8-284c-425a-8875-d74108e0cda5");

            await Svc<IRealEstateServices>().GetAsync(guid);

            Assert.Equal(correctGuid, guid);

        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealestate()
        {
            RealEstateDto realEstate = MockRealEstateData();

            var addRealEstate = await Svc<IRealEstateServices>().Create(realEstate);
            var result = await Svc<IRealEstateServices>().Delete((Guid)addRealEstate.Id);

            Assert.Equal(addRealEstate, result);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidDeleteRealestate()
        {
            RealEstateDto realEstate = MockRealEstateData();

            var RealEstate1 = await Svc<IRealEstateServices>().Create(realEstate);
            var RealEstate2 = await Svc<IRealEstateServices>().Create(realEstate);
            var result = await Svc<IRealEstateServices>().Delete((Guid)RealEstate2.Id);
           

            Assert.NotEqual(RealEstate1.Id, result.Id);
        }

        [Fact]

        public async Task Should_UpdateByIdRealEstate_WhenReturnsNotEqual()
        {
            RealEstateDto realEstate = MockRealEstateData();

            var addRealEstate = await Svc<IRealEstateServices>().Create(realEstate);
            RealEstateDto update = MockRealUpdateRealEstateData();
            var result = await Svc<IRealEstateServices>().Update(update);
            

            Assert.NotEqual(addRealEstate.Id, result.Id);

        }

        [Fact]

        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {

            var guid = Guid.Parse("58b815d8-284c-425a-8875-d74108e0cda5");
            //uued andmed
            RealEstateDto dto = MockRealEstateData();

            //andmebaasis olevad andmed
            RealEstateDto domain = new();

            domain.Id = Guid.Parse("58b815d8-284c-425a-8875-d74108e0cda5");
            domain.Location = "qwerty";
            domain.Size = 56;
            domain.RoomNumber = 111;
            domain.BuildingType = "hghg";
            domain.CreatedAt = DateTime.UtcNow;
            domain.ModifiedAt = DateTime.UtcNow;

            //Act
            var result = await Svc<IRealEstateServices>().Update(dto);

            //Assert
            Assert.Equal(domain.Id, guid);
            Assert.DoesNotMatch(domain.Location, dto.Location);
            Assert.DoesNotMatch(domain.RoomNumber.ToString(), dto.RoomNumber.ToString());
            Assert.NotEqual(domain.Size, dto.Size);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateDataVersion2()
        {

            RealEstateDto dto = MockRealEstateData();
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);

            RealEstateDto update = MockRealUpdateRealEstateData();
            var result = await Svc<IRealEstateServices>().Update(update);

            Assert.NotEqual(result.ModifiedAt, createRealEstate.ModifiedAt);

        }


        //Kodutoo

        [Fact]
        public async Task Should_ReturnNull_WhenGettingNonExistentRealEstate()
        {
            // Arrange
            Guid nonExistentId = Guid.NewGuid(); // ID does not exist

            // Act
            var result = await Svc<IRealEstateServices>().GetAsync(nonExistentId);

            // Assert
            Assert.Null(result); // result to be null for a non-existent real estate
        }


        [Fact]
        public async Task Should_ReturnRealEstate_WhenCreatedSuccessfully()
        {
            // Arrange
            RealEstateDto dto = MockRealEstateData();

            // Act
            var result = await Svc<IRealEstateServices>().Create(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dto.Location, result.Location);
            Assert.Equal(dto.Size, result.Size);
            Assert.Equal(dto.RoomNumber, result.RoomNumber);
            Assert.Equal(dto.BuildingType, result.BuildingType);
        }


        [Fact]
        public async Task Should_ReturnRealEstate_WhenFetchingById()
        {
            // Arrange
            var dto = MockRealEstateData();
            var createdRealEstate = await Svc<IRealEstateServices>().Create(dto);

            // Act
            var result = await Svc<IRealEstateServices>().GetAsync((Guid)createdRealEstate.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdRealEstate.Id, result.Id);
            Assert.Equal(dto.Location, result.Location);
            Assert.Equal(dto.Size, result.Size);
            Assert.Equal(dto.RoomNumber, result.RoomNumber);
            Assert.Equal(dto.BuildingType, result.BuildingType);
        }

        [Fact]
        public async Task Should_DeleteRealEstate_WhenExists()
        {
            // Arrange
            var realEstate = MockRealEstateData();
            var createdRealEstate = await Svc<IRealEstateServices>().Create(realEstate);

            // Act
            var result = await Svc<IRealEstateServices>().Delete((Guid)createdRealEstate.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdRealEstate.Id, result.Id); // Should return the deleted real estate
        }

        private RealEstateDto MockRealEstateData()
        {
            RealEstateDto realEstate = new()
            {
                Location = "asd",
                Size=100,
                RoomNumber=1,
                BuildingType="ASD",
                CreatedAt=DateTime.Now,
                ModifiedAt=DateTime.Now,
            };
            return realEstate;
        }


        private RealEstateDto MockRealUpdateRealEstateData()
        {
            RealEstateDto realEstate = new()
            {
                Location = "Tallinn",
                Size = 110,
                RoomNumber = 5,
                BuildingType = "ASD",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            return realEstate;
        }

        private RealEstateDto MockNullRealEstateData()
        {
            RealEstateDto nullDto = new()
            {
                Id = null,
                Location = "Tallinn",
                Size = 110,
                RoomNumber = 5,
                BuildingType = "ASD",
                CreatedAt = DateTime.Now.AddYears(-1),
                ModifiedAt = DateTime.Now.AddYears(-1),
            };
            return nullDto;
        }
    }
}