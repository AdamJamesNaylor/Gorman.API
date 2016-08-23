﻿

namespace AJN.Gorman.API.UnitTests {
    using System.Web.Http.Results;
    using System.Collections.ObjectModel;
    using AJN.Gorman.API.Controllers;
    using AJN.Gorman.API.Core.Services;
    using AJN.Gorman.Domain;
    using Moq;
    using Xunit;

    public class MapControllerTests {
        private Mock<IMapService> _fakeService;
        private MapController _mapController;

        [Fact]
        public void Post_WithMap_PassesMapToService() {
            _mapController.Post(new Map {Id = 123});

            _fakeService.Verify(s => s.Add(It.Is<Map>(m => m.Id == 123)));
        }

        [Fact]
        public void Post_WithNull_ReturnsBadRequest() {
            var response = _mapController.Post(null);
            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void Post_WithUserCredentials_PassesUserIdToMapService() {}

        [Fact]
        public void Get_WithExistingId_ReturnsExistingMap() {
            _fakeService.Setup(s => s.Get(123)).Returns(new Map() {Id = 123});
            var response = _mapController.Get(123);

            var result = Assert.IsType<OkNegotiatedContentResult<Map>>(response);

            Assert.Equal(123, result.Content.Id);
        }

        [Fact]
        public void Get_WithNonexistantId_Returns404() {
            var response = _mapController.Get(123);

            Assert.IsType<NotFoundResult>(response);
        }

        public MapControllerTests() {
            _fakeService = new Mock<IMapService>();
            _mapController = new MapController(_fakeService.Object);

            var map = new Map {
                Id = 123,
                Activities = new Collection<Activity> {
                    new Activity {
                        Id = 456,
                        Actors = new Collection<Actor> {
                            new Actor {
                                Id = 999,
                                ActivityId = 456,
                                ImageUrl = "http://something.com/something.gif"
                            }
                        },
                        MapId = 123,
                        Children = new Collection<Activity> {
                            new Activity {
                                Id = 789,
                                Actions = new Collection<Action> {
                                    new Action {
                                        Id = 111,
                                        Type = ActionType.Add,
                                        ActorId = 999
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }

}