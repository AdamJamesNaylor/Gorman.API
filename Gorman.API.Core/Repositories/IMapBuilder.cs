﻿
namespace Gorman.API.Core.Repositories {
    using System.Data.SQLite;
    using Domain;

    public interface IMapBuilder {
        Map Build(SQLiteDataReader reader);
    }

    public class MapBuilder : IMapBuilder {
        public Map Build(SQLiteDataReader reader) {
            return new Map {
                Id = reader.GetInt32("Id")
            };
        }
    }
}