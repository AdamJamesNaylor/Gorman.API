


using System.Collections.Generic;
using System.Data.Entity;
using Moq.Language.Flow;

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
            var maps = new List<Map>
            {
                new Map { Id = 1 },
                new Map { Id = 2 },
                new Map { Id = 3 },
                new Map { Id = 4 },
                new Map { Id = 123 }
            }.AsQueryable();

            _fakeContext.Setup(c => c.Maps).ReturnsSet(maps);
            var map = _mapService.Get(123);

            Assert.Equal(123, map.Id);
        }

        [Fact]
        public void Get_WithNonexistantId_ReturnsNull()
        {
            var emptySetOfMaps = new List<Map>().AsQueryable();

            _fakeContext.Setup(c => c.Maps).ReturnsSet(emptySetOfMaps);

            var nonExistantMapId = 123;
            var map = _mapService.Get(nonExistantMapId);

            Assert.Null(map);
        }

    }

    public static class ISetupExtensions {
        public static IReturnsResult<IEntitiesContext> ReturnsSet<T>(this ISetup<IEntitiesContext, DbSet<T>> operand, IQueryable<T> set) where T : class {
            var mapSet = new Mock<DbSet<T>>();
            mapSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(set.Provider);
            mapSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(set.Expression);
            mapSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(set.ElementType);
            mapSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(set.GetEnumerator());
            return operand.Returns(mapSet.Object);
        }
    }
}
