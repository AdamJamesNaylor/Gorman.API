namespace Gorman.API.Core.Repositories {
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using Builders;
    using Domain;

    public interface IActorRepository {
        Actor Add(Actor actor);
        Actor Get(long id);
        List<Actor> List(long activityId);
        List<ActorSummary> ListSummaries(long activityId);
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
                    command.CommandText = "INSERT INTO Actors (ActivityId, ImageUrl, PositionX, PositionY) VALUES (@activityId, @imageUrl, @positionX, @positionY); SELECT last_insert_rowid()";
                    command.Parameters.Add(new SQLiteParameter("@activityId", actor.ActivityId));
                    command.Parameters.Add(new SQLiteParameter("@imageUrl", actor.ImageUrl));
                    command.Parameters.Add(new SQLiteParameter("@positionX", actor.PositionX));
                    command.Parameters.Add(new SQLiteParameter("@positionY", actor.PositionY));
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
                        if (!reader.HasRows)
                            return null;
                        result = _actorBuilder.Build(reader);
                    }
                }
                connection.Close();

                return result;
            }
        }

        public List<Actor> List(long activityId) {
            return List(activityId, _actorBuilder.Build);
        }

        public List<ActorSummary> ListSummaries(long activityId) {
            return List(activityId, _actorBuilder.BuildSummary);
        }

        private List<T> List<T>(long activityId, Func<SQLiteDataReader, T> builder) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString)) {
                var result = new List<T>();
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = "SELECT * FROM Actors WHERE ActivityId = @activityId";
                    command.Parameters.Add(new SQLiteParameter("@activityId", activityId));
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            result.Add(builder(reader));
                        }
                    }
                }
                connection.Close();

                return result;
            }
        }

        private readonly IActorBuilder _actorBuilder;
    }
}