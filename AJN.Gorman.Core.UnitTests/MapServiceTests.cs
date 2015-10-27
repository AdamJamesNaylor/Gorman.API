


namespace AJN.Gorman.Core.UnitTests
{
    using API.Core.Services;
    using Domain;
    using Microsoft.Data.Entity;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class MapServiceTests
    {
        [Test]
        public void Add_WithNewMap_AddsToDatastore()
        {
            var fakeContext = new Mock<IEntitiesContext>();
            var fakeMapSet = new Mock<DbSet<Map>>();
            fakeContext.Setup(c => c.Maps).Returns(fakeMapSet.Object);
            var mapService = new MapService(fakeContext.Object);

            mapService.Add(new Map());

            fakeMapSet.Verify(c => c.Add(It.IsAny<Map>(), GraphBehavior.IncludeDependents)); //have to include optional argument
            fakeContext.Verify(c=>c.SaveChanges());
        }
    }
}
