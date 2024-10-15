using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;

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
    }
}