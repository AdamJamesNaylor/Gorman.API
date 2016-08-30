namespace Gorman.API.Core.Repositories {
    using System;
    using System.Data.SQLite;
    using System.IO;

    public abstract class BaseRepository {
        public string DatabaseFileName { get; }
        public string ConnectionString { get; }

        protected bool IsInitialised { get; set; }

        protected BaseRepository() {
            IsInitialised = false;

            var dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            DatabaseFileName = Path.Combine(dataDirectory, "Gorman.API.sqlite");
            ConnectionString = $"Data Source={DatabaseFileName};Version=3";
        }

        protected virtual void Initialise() {
            if (IsInitialised)
                return;

            IsInitialised = false;

            if (!File.Exists(DatabaseFileName))
                CreateDatabase(DatabaseFileName);

            IsInitialised = true;
        }

        private void CreateDatabase(string databaseFileName) {
            SQLiteConnection.CreateFile(databaseFileName);

            using (var connection = new SQLiteConnection(ConnectionString)) {
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = Resources.CreateDatabase;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}