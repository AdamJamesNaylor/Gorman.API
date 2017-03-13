namespace Gorman.API.Core.Repositories {
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using Builders;
    using Domain;

    public interface IActionParameterRepository {
        ActionParameter Add(ActionParameter actionParameter);
        ActionParameter Get(long id);
        List<ActionParameter> List(long actionId);
        List<ActionParameterSummary> ListSummaries(long actionId);
    }

    public class ActionParameterRepository
        : BaseRepository, IActionParameterRepository {

        public ActionParameterRepository(IActionParameterBuilder actionParameterBuilder)
        {
            _actionParameterBuilder = actionParameterBuilder;
        }

        public ActionParameter Add(ActionParameter actionParameter)
        {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "INSERT INTO ActionParameters (ActionId, Key, Value) VALUES (@actionId, @key, @value); SELECT last_insert_rowid()";
                    command.Parameters.Add(new SQLiteParameter("@actionId", actionParameter.ActionId));
                    command.Parameters.Add(new SQLiteParameter("@key", actionParameter.Key));
                    command.Parameters.Add(new SQLiteParameter("@value", actionParameter.Value));
                    var rowId = command.ExecuteScalar();

                    command.CommandText = "SELECT Id FROM ActionParameters WHERE rowid = @rowId";
                    command.Parameters.Add(new SQLiteParameter("@rowId", rowId));
                    actionParameter.Id = (long)command.ExecuteScalar();
                }
                connection.Close();
                return actionParameter;
            }
        }

        public ActionParameter Get(long id)
        {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                ActionParameter result;
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM ActionParameters WHERE Id = @id";
                    command.Parameters.Add(new SQLiteParameter("@id", id));
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        result = _actionParameterBuilder.Build(reader);
                    }
                }
                connection.Close();

                return result;
            }
        }

        public List<ActionParameter> List(long actionId)
        {
            return List(actionId, _actionParameterBuilder.Build);
        }

        public List<ActionParameterSummary> ListSummaries(long actionId)
        {
            return List(actionId, _actionParameterBuilder.BuildSummary);
        }

        private List<T> List<T>(long actionId, Func<SQLiteDataReader, T> builder)
        {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = new List<T>();
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM ActionParameters WHERE ActionId = @actionId";
                    command.Parameters.Add(new SQLiteParameter("@actionId", actionId));
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

        private readonly IActionParameterBuilder _actionParameterBuilder;
    }
}