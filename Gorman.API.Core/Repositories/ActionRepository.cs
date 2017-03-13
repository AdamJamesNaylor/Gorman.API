
namespace Gorman.API.Core.Repositories {
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using Builders;
    using Domain;
    using Action = Domain.Action;

    public interface IActionRepository {
        Action Add(Action action);
        Action Get(long id);
        List<Action> List(long activityId);
        List<ActionSummary> ListSummaries(long activityId);
    }

    public class ActionRepository
        : BaseRepository, IActionRepository {

        public ActionRepository(IActionBuilder actionBuilder) {
            _actionBuilder = actionBuilder;
        }

        public Action Add(Action action) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString)) {
                Action result;
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText =
                        "INSERT INTO Actions (ActivityId, ActorId) VALUES (@activityId, @actorId); SELECT last_insert_rowid()";
                    command.Parameters.Add(new SQLiteParameter("@activityId", action.ActivityId));
                    command.Parameters.Add(new SQLiteParameter("@actorId", action.ActorId));
                    var rowId = command.ExecuteScalar();

                    command.CommandText = "SELECT Id FROM Actions WHERE rowid = @rowId";
                    command.Parameters.Add(new SQLiteParameter("@rowId", rowId));
                    var id = (long) command.ExecuteScalar();
                    result = Get(id);
                }
                connection.Close();
                return result;
            }
        }

        public Action Get(long id) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString)) {
                Action result;
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = "SELECT * FROM Actions WHERE Id = @id";
                    command.Parameters.Add(new SQLiteParameter("@id", id));
                    using (var reader = command.ExecuteReader()) {
                        reader.Read();
                        if (!reader.HasRows)
                            return null;

                        result = _actionBuilder.Build(reader);
                    }
                }
                connection.Close();

                return result;
            }
        }

        public List<Action> List(long activityId) {
            return List(activityId, _actionBuilder.Build);
        }

        public List<ActionSummary> ListSummaries(long activityId) {
            return List(activityId, _actionBuilder.BuildSummary);
        }

        private List<T> List<T>(long activityId, Func<SQLiteDataReader, T> builder) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = new List<T>();
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Actions WHERE ActivityId = @activityId";
                    command.Parameters.Add(new SQLiteParameter("@activityId", activityId));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(builder(reader));
                        }
                    }
                }
                connection.Close();

                return result;
            }

        }

        private readonly IActionBuilder _actionBuilder;

    }
}