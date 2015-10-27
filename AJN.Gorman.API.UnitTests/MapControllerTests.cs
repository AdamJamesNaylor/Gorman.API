
using System.Web.Http.Results;

namespace AJN.Gorman.API.UnitTests
{
    using AJN.Gorman.API.Controllers;
    using AJN.Gorman.API.Core.Services;
    using AJN.Gorman.Domain;
    using Moq;
    using Xunit;

    public class MapControllerTests
    {
        private Mock<IMapService> _fakeService;
        private MapController _mapController;

        [Fact]
        public void Post_WithMap_PassesMapToService()
        {          
            _mapController.Post(new Map { Id = 123 });

            _fakeService.Verify(s => s.Add(It.Is<Map>(m => m.Id == 123)));
        }

        [Fact]
        public void Post_WithNull_ReturnsBadRequest()
        {
            var response = _mapController.Post(null);
            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void Post_WithUserCredentials_PassesUserIdToMapService()
        {
            
        }

        [Fact]
        public void Get_WithExistingId_ReturnsExistingMap() {
            var response = _mapController.Get(123);
            var result = Assert.IsType<OkNegotiatedContentResult<Map>>(response);

            Assert.Equal(123, result.Content.Id);
        }

        public MapControllerTests()
        {
            _fakeService = new Mock<IMapService>();
            _mapController = new MapController(_fakeService.Object);
        }
    }
}
