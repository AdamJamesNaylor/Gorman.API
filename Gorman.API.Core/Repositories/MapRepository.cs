
namespace Gorman.API.Core.Repositories {
    using System.Data.SQLite;
    using Builders;
    using Domain;

    public interface IMapRepository {
        Map Add(Map map);
        Map Get(long id);
    }

    public class MapRepository
        : BaseRepository, IMapRepository {

        public MapRepository(IMapBuilder mapBuilder) {
            _mapBuilder = mapBuilder;
        }

        public Map Add(Map map) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString)) {
                Map result;
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = "INSERT INTO Maps (TileUrl) VALUES (@tileUrl); SELECT last_insert_rowid()";
                    command.Parameters.Add(new SQLiteParameter("@tileUrl", map.TileUrl));
                    var rowId = command.ExecuteScalar();

                    command.CommandText = "SELECT Id FROM Maps WHERE rowid = @rowId";
                    command.Parameters.Add(new SQLiteParameter("@rowId", rowId));
                    var id = (long) command.ExecuteScalar();
                    result = Get(id);
                }
                connection.Close();
                return result;
            }
        }

        public Map Get(long id) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString)) {
                Map map;
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = "SELECT * FROM Maps WHERE Id = @id";
                    command.Parameters.Add(new SQLiteParameter("@id", id));
                    using (var reader = command.ExecuteReader()) {
                        map = _mapBuilder.Build(reader);
                    }
                }
                connection.Close();

                return map;
            }
        }

        private readonly IMapBuilder _mapBuilder;
    }
}