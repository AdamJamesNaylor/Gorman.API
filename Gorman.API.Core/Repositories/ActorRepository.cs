namespace Gorman.API.Core.Repositories {
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Common;
    using System.Data.SQLite;
    using Builders;
    using Domain;

    public interface IActorRepository {
        Actor Add(Actor actor);
        Actor Get(long id);
        ReadOnlyCollection<Actor> List(long mapId);
    }

    public class ActorRepository
        : BaseRepository, IActorRepository {

        public ActorRepository(IActorBuilder actorBuilder) {
            _actorBuilder = actorBuilder;
        }

        public Actor Add(Actor actor) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString)) {
                Actor result;
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = "INSERT INTO Actors (MapId) VALUES (@mapId); SELECT last_insert_rowid()";
                    command.Parameters.Add(new SQLiteParameter("@mapId", actor.MapId));
                    var rowId = command.ExecuteScalar();

                    command.CommandText = "SELECT Id FROM Actors WHERE rowid = @rowId";
                    command.Parameters.Add(new SQLiteParameter("@rowId", rowId));
                    var id = (long) command.ExecuteScalar();
                    result = Get(id);
                }
                connection.Close();
                return result;
            }
        }

        public Actor Get(long id) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString)) {
                Actor result;
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = "SELECT * FROM Actors WHERE Id = @id";
                    command.Parameters.Add(new SQLiteParameter("@id", id));
                    using (var reader = command.ExecuteReader()) {
                        reader.Read();
                        result = _actorBuilder.Build(reader);
                    }
                }
                connection.Close();

                return result;
            }
        }

        public ReadOnlyCollection<Actor> List(long mapId) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString)) {
                var result = new List<Actor>();
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = "SELECT * FROM Actors WHERE MapId = @id";
                    command.Parameters.Add(new SQLiteParameter("@id", mapId));
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            result.Add(_actorBuilder.Build(reader));
                        }
                    }
                }
                connection.Close();

                return result.AsReadOnly();
            }
        }

        private readonly IActorBuilder _actorBuilder;
    }
}