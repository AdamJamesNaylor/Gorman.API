


namespace AJN.Gorman.Core.UnitTests
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using API.Core.Services;
    using Domain;
    using Microsoft.Data.Entity;
    using Moq;
    using Xunit;

    public class MapServiceTests
    {
        private Mock<IEntitiesContext> _fakeContext;
        private Mock<DbSet<Map>> _fakeMapSet;
        private MapService _mapService;

        public MapServiceTests() {
            _fakeContext = new Mock<IEntitiesContext>();
            _fakeMapSet = new Mock<DbSet<Map>>();
            _fakeContext.Setup(c => c.Maps).Returns(_fakeMapSet.Object);
            _mapService = new MapService(_fakeContext.Object);
        }

        [Fact]
        public void Add_WithNewMap_AddsToDatastore()
        {
            _mapService.Add(new Map());

            _fakeMapSet.Verify(c => c.Add(It.IsAny<Map>(), GraphBehavior.IncludeDependents)); //have to include optional argument
            _fakeContext.Verify(c=>c.SaveChanges());
        }

        [Fact]
        public void Get_WithExistingId_ReturnsExistingMap() {
            _fakeMapSet.Setup(s => s.First(It.IsAny<Expression<Func<Map, bool>>>())).Returns(new Map() {Id = 123});
            var map = _mapService.Get(123);

            Assert.Equal(123, map.Id);
        }

        [Fact]
        public void Get_WithExistingId_ReturnsExistingMap2()
        {
            var map = _mapService.Get(123);

            Assert.Equal(123, map.Id);
        }

    }
}
