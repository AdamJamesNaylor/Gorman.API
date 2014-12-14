using System.Collections.Generic;

namespace AJN.Gorman.API.Models
{
    public class ActionAddPostModel {

        public ActionType Type { get; set; }
        public int ActionId { get; set; }
        public string ImageUri { get; set; }
        public IEnumerable<ActionPositionAddPostModel> Positions { get; set; }
    }
}