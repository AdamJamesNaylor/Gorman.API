namespace AJN.Gorman.API.Models
{
    public class ActionPositionAddPostModel {

        public int X { get; set; }
        public int Y { get; set; }
        public float Scale { get; set; }
        public float Rotation { get; set; }

        public ActionPositionAddPostModel() {
            X = 0;
            Y = 0;
            Scale = 1.0f;
            Rotation = 0.0f;
        }
    }
}