
namespace AJN.Gorman.Domain {
    using System.Collections.ObjectModel;

    public class Activity {
        public int Id { get; set; }

        public int ParentId { get; set; }
        public Collection<Activity> Children { get; set; }

        public int MapId { get; set; }

        public Collection<Actor> Actors { get; set; }
        public Collection<Action> Actions { get; set; }

        public Activity() {
            Children = new Collection<Activity>();
            Actors = new Collection<Actor>();
            Actions = new Collection<Action>();
        }
    }
}
