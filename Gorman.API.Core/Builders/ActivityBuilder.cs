namespace Gorman.API.Core.Builders {
    using System.Data.Common;
    using Domain;

    public interface IActivityBuilder {
        Activity Build(DbDataReader reader);
    }

    public class ActivityBuilder
        : IActivityBuilder {

        public const string IdField = "{activityId}";
        public const string ActivitiesUrl = "/activities/" + IdField;

        public Activity Build(DbDataReader reader) {
            var result = new Activity {
                Id = reader.GetInt64("Id"),
                ParentId = reader.GetInt64("ParentId"),
                MapId = reader.GetInt64("MapId")
            };
            result.Url = ActivitiesUrl.Replace(IdField, result.Id.ToString());
            result.ActionsUrl = ActionBuilder.ActionsUrl.Replace(IdField, result.Id.ToString());
            result.MapUrl = MapBuilder.MapsUrl.Replace(MapBuilder.IdField, result.MapId.ToString());
            return result;
        }
    }
}