namespace Gorman.API.Core.Builders {
    using System.Data.Common;
    using Domain;

    public interface IActorBuilder {
        Actor Build(DbDataReader reader);
        ActorSummary BuildSummary(DbDataReader reader);
    }

    public class ActorBuilder
        : IActorBuilder {

        public const string IdField = "{actorId}";
        public const string ActorsUrl = ActivityBuilder.ActivitiesUrl + "/actors/" + IdField;

        public Actor Build(DbDataReader reader) {
            var result = new Actor {
                Id = reader.GetInt64("Id"),
                ActivityId = reader.GetInt64("ActivityId"),
                ImageUrl = reader.GetString("ImageUrl"),
                PositionX = reader.GetInt64("PositionX"),
                PositionY = reader.GetInt64("PositionY")
            };
            result.Url = BuildUrl(result.ActivityId, result.Id);
            return result;
        }

        private static string BuildUrl(long activityId, long actorId) {
            return ActorsUrl.Replace(ActivityBuilder.IdField, activityId.ToString()).Replace(IdField, actorId.ToString());
        }

        public ActorSummary BuildSummary(DbDataReader reader)
        {
            var result = new ActorSummary
            {
                Id = reader.GetInt64("Id"),
            };
            var activityId = reader.GetInt64("ActivityId");
            result.Url = BuildUrl(activityId, result.Id);
            return result;
        }

    }
}