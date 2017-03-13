namespace Gorman.API.Core.Builders {
    using System.Data.Common;
    using Domain;

    public interface IActionBuilder {
        Action Build(DbDataReader reader);
        ActionSummary BuildSummary(DbDataReader reader);
    }

    public class ActionBuilder
        : IActionBuilder {
        public const string IdField = "{actionId}";
        public const string ActionsUrl = ActivityBuilder.ActivitiesUrl + "/actions/" + IdField;

        public Action Build(DbDataReader reader) {
            var result = new Action {
                Id = reader.GetInt64("Id"),
                ActivityId = reader.GetInt64("ActivityId"),
                ActorId = reader.GetInt64("ActorId")
            };
            result.Url = ActionsUrl.Replace(ActivityBuilder.IdField, result.ActivityId.ToString()).Replace(IdField, result.Id.ToString());
            return result;
        }

        public ActionSummary BuildSummary(DbDataReader reader) {
            var result = new ActionSummary {
                Id = reader.GetInt64("Id"),
            };
            var activityId = reader.GetInt64("ActivityId");
            result.Url = ActionsUrl.Replace(ActivityBuilder.IdField, activityId.ToString()).Replace(IdField, result.Id.ToString());
            return result;
        }

    }
}