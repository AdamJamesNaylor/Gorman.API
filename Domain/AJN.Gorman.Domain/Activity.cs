
namespace AJN.Gorman.Domain {
    using System.Collections.Generic;

    public class Activity {
        public int Id { get; set; }

        public int ParentId { get; set; }
        public ICollection<Activity> Children { get; set; }

        public int MapId { get; set; }

        public ICollection<Action> Actions { get; set; }


    }
}
