
namespace Gorman.API.Core.Builders {
    using System.Data.Common;
    using Domain;

    public interface IActivitySummaryBuilder {
        ActivitySummary Build(DbDataReader reader);
    }

    public class ActivitySumaryBuilder
        : IActivitySummaryBuilder {

        public const string IdField = "{activityId}";
        public const string ActivitiesUrl = "/activities/" + IdField;

        public ActivitySummary Build(DbDataReader reader) {
            var result = new ActivitySummary {
                Id = reader.GetInt64("Id"),
            };
            result.Url = ActivitiesUrl.Replace(IdField, result.Id.ToString());
            return result;
        }
    }
}