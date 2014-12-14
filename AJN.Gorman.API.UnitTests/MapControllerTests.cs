
using System.Web.Http.Results;

namespace AJN.Gorman.API.UnitTests
{
    using AJN.Gorman.API.Controllers;
    using AJN.Gorman.API.Core.Services;
    using AJN.Gorman.Domain;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class MapControllerTests
    {
        private Mock<IMapService> _fakeService;
        private MapController _mapController;

        [Test]
        public void Post_WithMap_PassesMapToService()
        {          
            _mapController.Post(new Map { Id = 123 });

            _fakeService.Verify(s => s.Add(It.Is<Map>(m => m.Id == 123)));
        }

        [Test]
        public void Post_WithNull_ReturnsBadRequest()
        {
            var response = _mapController.Post(null);
            Assert.IsInstanceOf<BadRequestResult>(response);
        }

        [Test]
        public void Post_WithUserCredentials_PassesUserIdToMapService()
        {
            
        }

        [TestFixtureSetUp]
        public void SetUp()
        {
            _fakeService = new Mock<IMapService>();
            _mapController = new MapController(_fakeService.Object);
        }
    }
}
