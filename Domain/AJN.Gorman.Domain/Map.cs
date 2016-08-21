

namespace AJN.Gorman.Domain {
    using System;
    using System.Collections.Generic;

    public class Map
        : IEquatable<Map> {

        public int Id { get; set; }

        public string Name { get; set; }
        public string TileUrl { get; set; }
        public string Privacy { get; set; }

        public ICollection<Activity> Activities { get; set; }

        public int CompareTo(Map other) {
            if (Id == other.Id &&
                Name == other.Name &&
                TileUrl == other.TileUrl &&
                Privacy == other.Privacy)
                return 0;

            //better to return the correct sort order rather than just -1
            //http://msdn.microsoft.com/en-us/library/system.icomparable.compareto%28v=vs.110%29.aspx
            return -1;
        }

        public bool Equals(Map other) {
            return Id.Equals(other.Id) &&
                   string.Equals(Name, other.Name) &&
                   string.Equals(TileUrl, other.TileUrl) &&
                   string.Equals(Privacy, other.Privacy);
        }

    }
}