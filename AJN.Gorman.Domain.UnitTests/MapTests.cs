using NUnit.Framework;

namespace AJN.Gorman.Domain.UnitTests
{
    [TestFixture]
    public class MapTests
    {
        [Test]
        public void Equals_WithEqualMap_ReturnsTrue()
        {
            Map x = new Map
            {

            };

            Map y = new Map
            {

            };

            Assert.IsTrue(x.Equals(y));
        }

        [Test]
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

            Assert.IsFalse(x.Equals(y));
        }


    }
}
