

namespace AJN.Gorman.Core.UnitTests {
    using System.Data.Entity;
    using AJN.Gorman.API.Core.Services;
    using AJN.Gorman.Domain;
    using Moq;
    using Xunit;
    using AJN.Gorman.API.Core;

    public class PlanServiceTests {

        public PlanServiceTests() {
            _fakeContext = new Mock<IEntitiesContext>();
            _fakeSet = new Mock<DbSet<Plan>>();
            _fakeContext.Setup(c => c.Plans).Returns(_fakeSet.Object);
            _service = new PlanService(_fakeContext.Object);
        }

        [Fact]
        public void Add_WithPlan_ReturnsCorrectId() {
            _fakeSet.Setup(s => s.Add(It.IsAny<Plan>()))
                .Callback<Plan>(p => p.Id = 123);

            var subject = new Plan();
            _service.Add(subject);

            Assert.Equal(123, subject.Id);
        }

        [Fact]
        public void Update_WithPlan_UpdatesSetWithSuppliedPlan() {
            var subject = new Plan { Id = 123 };
            _service.Update(subject);

            _fakeSet.Verify(s => s.Add(It.Is<Plan>(p => p.Id == 123)));
        }

        private readonly Mock<IEntitiesContext> _fakeContext;
        private readonly Mock<DbSet<Plan>> _fakeSet;
        private readonly PlanService _service;

    }
}