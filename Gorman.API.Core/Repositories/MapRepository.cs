
namespace Gorman.API.Core.Repositories {
    using System;
    using System.Data.SQLite;
    using Domain;

    public interface IMapRepository {
        void Add(Map map);
        Map Get(int id);
    }

    public class MapRepository
        : BaseRepository, IMapRepository {

        public MapRepository(IMapBuilder mapBuilder) {
            _mapBuilder = mapBuilder;
        }

        public Map Get(int id) {
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

        public void Add(Map map) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString)) {
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = "INSERT INTO Maps (Id) VALUES (@id)";
                    command.Parameters.Add(new SQLiteParameter("@id", map.Id));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        private readonly IMapBuilder _mapBuilder;
    }


    public static class SqliteDataReaderExtensions {
        public static int GetInt32(this SQLiteDataReader reader, string columnName) {
            var ordinal = reader.GetOrdinal(columnName);
            return reader.GetInt32(ordinal);
        }
    }
}

