namespace Gorman.API.Core.Builders {
    using System.Data.Common;
    using Domain;

    public interface IActionParameterBuilder {
        ActionParameter Build(DbDataReader reader);
        ActionParameterSummary BuildSummary(DbDataReader reader);
    }

    public class ActionParameterBuilder
        : IActionParameterBuilder {
        //public const string IdField = "{actionId}";
        //public const string ActionsUrl = ActivityBuilder.ActivitiesUrl + "/actions/" + IdField;

        public ActionParameter Build(DbDataReader reader)
        {
            var result = new ActionParameter {
                Id = reader.GetInt64("Id"),
                Key = reader.GetString("Key"),
                Value = reader.GetString("Value"),
            };
            //result.Url = ActionsUrl.Replace(ActivityBuilder.IdField, result.ActivityId.ToString()).Replace(IdField, result.Id.ToString());
            return result;
        }

        public ActionParameterSummary BuildSummary(DbDataReader reader) {
            var result = new ActionParameterSummary {
                Id = reader.GetInt64("Id"),
            };
            //result.Url = ActionsUrl.Replace(ActivityBuilder.IdField, activityId.ToString()).Replace(IdField, result.Id.ToString());
            return result;
        }

    }
}