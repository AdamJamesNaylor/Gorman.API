namespace AJN.Gorman.Domain
{
    public class Action
    {
        public int Id { get; set; }
        public int TargetId { get; set; }
        public ActionType Type { get; set; }
    }

}