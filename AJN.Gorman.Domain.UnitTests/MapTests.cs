
using Xunit;

namespace AJN.Gorman.Domain.UnitTests
{
    public class MapTests
    {
        [Fact]
        public void Equals_WithEqualMap_ReturnsTrue()
        {
            Map x = new Map
            {

            };

            Map y = new Map
            {

            };

            Assert.True(x.Equals(y));
        }

        [Fact]
        public void Equals_WithInequalMap_ReturnsFalse()
        {
            Map x = new Map
            {
                Id = 123
            };

            Map y = new Map
            {
                Id = 456
            };

            Assert.False(x.Equals(y));
        }


    }
}
