using Models.Enums;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
            this.RoomImages = new HashSet<RoomImages>();

        }
        public string Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public RoomType? ImageType { get; set; }

        public ImageType? Type { get; set; }

        public virtual ICollection<RoomImages> RoomImages { get; set; }
    }
}
