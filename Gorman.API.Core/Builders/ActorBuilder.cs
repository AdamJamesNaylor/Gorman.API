namespace Gorman.API.Core.Builders {
    using System.Data.Common;
    using Domain;

    public interface IActorBuilder {
        Actor Build(DbDataReader reader);
    }

    public class ActorBuilder
        : IActorBuilder {

        public const string IdField = "{actorId}";
        public const string ActorsUrl = "/actors/" + IdField;

        public Actor Build(DbDataReader reader) {
            var result = new Actor {
                Id = reader.GetInt64("Id"),
                ActivityId = reader.GetInt64("ActivityId"),
                ImageUrl = reader.GetString("ImageUrl"),
                PositionX = reader.GetInt64("PositionX"),
                PositionY = reader.GetInt64("PositionY")
            };
            result.Url = ActorsUrl.Replace(IdField, result.Id.ToString());
            return result;
        }
    }
}