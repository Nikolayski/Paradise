using System;

namespace Models
{
    public class RoomImages
    {
        public RoomImages()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string RoomId { get; set; }
        public virtual Room Room { get; set; }

        public string ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
