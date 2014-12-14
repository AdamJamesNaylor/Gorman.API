using System.Collections.Generic;

namespace AJN.Gorman.API.Models
{
    public class StepAddPostModel {

        public int PhaseId { get; set; }
        public int Index { get; set; }
        public IEnumerable<ActionAddPostModel> Actions { get; set; }
    }
}