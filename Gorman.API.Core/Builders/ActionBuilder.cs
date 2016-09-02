namespace Gorman.API.Core.Builders {
    using System.Data.Common;
    using Domain;

    public interface IActionBuilder {
        Action Build(DbDataReader reader);
    }

    public class ActionBuilder
        : IActionBuilder {
        public const string IdField = "{actionId}";
        public const string ActionsUrl = "/actions/" + IdField;

        public Action Build(DbDataReader reader) {
            var result = new Action {
                Id = reader.GetInt64("Id"),
                ActivityId = reader.GetInt64("ActivityId"),
                ActorId = reader.GetInt64("ActorId")
            };
            result.Url = ActionsUrl.Replace(IdField, result.Id.ToString());
            return result;
        }
    }
}