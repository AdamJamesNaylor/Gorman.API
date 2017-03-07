
namespace Gorman.API.Core.Builders {
    using System.Data.Common;
    using Domain;

    public interface IMapBuilder {
        Map Build(DbDataReader reader);
    }

    public class MapBuilder
        : IMapBuilder {

        public const string IdField = "{mapId}";
        public const string MapsUrl = "/maps/" + IdField;
        public const string ActivitiesUrl = MapsUrl + "/activities";
        public const string ActorsUrl = MapsUrl + "/actors";

        public Map Build(DbDataReader reader) {
            Map result = null;
            while (reader.Read()) {
                result = new Map {
                    Id = reader.GetInt64("Id"),
                    TileUrl = reader.GetString("TileUrl")
                };
                result.Url = MapsUrl.Replace(IdField, result.Id.ToString());
                result.ActivitiesUrl = ActivitiesUrl.Replace(IdField, result.Id.ToString());
                result.ActorsUrl = ActorsUrl.Replace(IdField, result.Id.ToString());
            }
            return result;
        }
    }

    public static class DbDataReaderExtensions {
        public static int GetInt32(this DbDataReader reader, string columnName) {
            var ordinal = reader.GetOrdinal(columnName);
            return reader.GetInt32(ordinal);
        }
        public static long GetInt64(this DbDataReader reader, string columnName) {
            var ordinal = reader.GetOrdinal(columnName);
            return reader.GetInt32(ordinal);
        }
        public static string GetString(this DbDataReader reader, string columnName)
        {
            var ordinal = reader.GetOrdinal(columnName);
            if (reader.IsDBNull(ordinal))
                return null;
            return reader.GetString(ordinal);
        }

    }
}