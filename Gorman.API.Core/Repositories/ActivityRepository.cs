﻿namespace Gorman.API.Core.Repositories {
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.SQLite;
    using Builders;
    using Domain;

    public interface IActivityRepository {
        Activity Add(Activity activity);
        Activity Get(long id);
        ReadOnlyCollection<Activity> List(long mapId);
    }

    public class ActivityRepository
        : BaseRepository, IActivityRepository {

        public ActivityRepository(IActivityBuilder activityBuilder) {
            _activityBuilder = activityBuilder;
        }

        public Activity Add(Activity activity) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString)) {
                Activity result;
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText =
                        "INSERT INTO Activities (ParentId, MapId) VALUES (@ParentId, @MapId); SELECT last_insert_rowid()";
                    command.Parameters.Add(new SQLiteParameter("@ParentId", activity.ParentId));
                    command.Parameters.Add(new SQLiteParameter("@MapId", activity.MapId));
                    var rowId = command.ExecuteScalar();

                    command.CommandText = "SELECT Id FROM Activities WHERE rowid = @rowId";
                    command.Parameters.Add(new SQLiteParameter("@rowId", rowId));
                    var id = (long) command.ExecuteScalar();
                    result = Get(id);
                }
                connection.Close();
                return result;
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

        public ReadOnlyCollection<Activity> List(long mapId) {
            Initialise();

            using (var connection = new SQLiteConnection(ConnectionString)) {
                var result = new List<Activity>();
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = "SELECT * FROM Activities WHERE MapId = @id";
                    command.Parameters.Add(new SQLiteParameter("@id", mapId));
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            result.Add(_activityBuilder.Build(reader));
                        }
                    }
                }
                connection.Close();

                return result.AsReadOnly();
            }
        }

        private readonly IActivityBuilder _activityBuilder;
    }
}