
namespace AJN.Gorman.Core.UnitTests {

    using AJN.Gorman.API.Core.Services;
    using AJN.Gorman.Domain;
    using Microsoft.Data.Entity;
    using Moq;
    using Xunit;

    public class PlanServiceTests {

        public PlanServiceTests() {
            _fakeContext = new Mock<IEntitiesContext>();
            _fakeSet = new Mock<DbSet<Plan>>();
            _fakeContext.Setup(c => c.Plans).Returns(_fakeSet.Object);
            _service = new PlanService(_fakeContext.Object);
        }

        [Fact]
        public void Add_WithPlan_ReturnsCorrectId() {
            _fakeSet.Setup(s => s.Add(It.IsAny<Plan>(), GraphBehavior.IncludeDependents))
                .Callback<Plan, GraphBehavior>((p, x) => p.Id = 123);

            var subject = new Plan();
            _service.Add(subject);

            Assert.Equal(123, subject.Id);
        }

        [Fact]
        public void Update_WithPlan_AddsToSet() {
            var subject = new Plan();
            _service.Update(subject);

            Assert.Equal(123, subject.Id);
        }

        private readonly Mock<IEntitiesContext> _fakeContext;
        private readonly Mock<DbSet<Plan>> _fakeSet;
        private readonly PlanService _service;

    }
}