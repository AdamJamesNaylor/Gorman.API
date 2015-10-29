using System.Collections.Generic;

namespace AJN.Gorman.Domain
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Step> Steps{ get; set; }
    }
}