

using System.Data.Entity;
using AJN.Gorman.API.Core.Services;
using AJN.Gorman.Domain;
using Moq;

namespace AJN.Gorman.Core.UnitTests
{
    using NUnit.Framework;

    [TestFixture]
    public class MapServiceTests
    {
        [Test]
        public void Add_WithNewMap_AddsToDatastore()
        {
            var fakeContext = new Mock<IEntitiesContext>();
            var fakeMapSet = new Mock<IDbSet<Map>>();
            fakeContext.Setup(c => c.Maps).Returns(fakeMapSet.Object);
            var mapService = new MapService(fakeContext.Object);

            mapService.Add(new Map());

            fakeMapSet.Verify(c => c.Add(It.IsAny<Map>()));
            fakeContext.Verify(c=>c.SaveChanges());
        }
    }
}
