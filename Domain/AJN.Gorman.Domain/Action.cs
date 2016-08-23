namespace AJN.Gorman.Domain {
    public class Action {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public ActionType Type { get; set; }
    }
}