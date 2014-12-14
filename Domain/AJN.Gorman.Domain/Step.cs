
namespace AJN.Gorman.Domain
{
    using System.Collections.Generic;

    public class Step
    {
        public int Id { get; set; }
        public int PhaseId { get; set; }
        public int Index { get; set; }
        public ICollection<Action> Actions { get; set; }
    }
}