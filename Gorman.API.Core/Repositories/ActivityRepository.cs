namespace Gorman.API.Core.Repositories {
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.SQLite;
    using System.Linq;
    using Builders;
    using Domain;

    public interface IActivityRepository {
        Activity Add(Activity activity);
        Activity Get(long id);
        List<Activity> List(long parentActivityId);
        List<ActivitySummary> ListSummaries(long parentActivityId);
    }

    public class ActivityRepository
        : BaseRepository, IActivityRepository {

        public ActivityRepository(IActivityBuilder activityBuilder) {
            _activityBuilder = activityBuilder;
        }

        public Activity Add(Activity activity) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString)) {
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = "INSERT INTO Activities (ParentId, MapId) VALUES (@ParentId, @MapId); SELECT last_insert_rowid()";
                    command.Parameters.Add(new SQLiteParameter("@ParentId", activity.ParentId));
                    command.Parameters.Add(new SQLiteParameter("@MapId", activity.MapId));
                    var rowId = command.ExecuteScalar();

                    command.CommandText = "SELECT Id FROM Activities WHERE rowid = @rowId";
                    command.Parameters.Add(new SQLiteParameter("@rowId", rowId));
                    activity.Id = (long) command.ExecuteScalar();

                }
                connection.Close();
                return activity;
            }

        }

        public Activity Get(long id) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString)) {
                Activity result;
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = "SELECT * FROM Activities WHERE Id = @id";
                    command.Parameters.Add(new SQLiteParameter("@id", id));
                    using (var reader = command.ExecuteReader()) {
                        reader.Read();
                        result = _activityBuilder.Build(reader);
                    }
                }
                connection.Close();

                return result;
            }
        }

        public List<Activity> List(long parentActivityId) {
            return List(parentActivityId, _activityBuilder.Build);
        }

        public List<ActivitySummary> ListSummaries(long parentActivityId) {
            return List(parentActivityId, _activityBuilder.BuildSummary);
        }

        private List<T> List<T>(long parentActivityId, Func<SQLiteDataReader, T> builder) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = new List<T>();
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Activities WHERE parentId = @parentActivityId";
                    command.Parameters.Add(new SQLiteParameter("@parentActivityId", parentActivityId));
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

        private readonly IActivityBuilder _activityBuilder;
    }
}