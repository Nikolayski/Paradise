using Models.Enums;

using System;
using System.Collections.Generic;

namespace Models
{
    public class Room
    {
        public Room()
        {
            this.Id = Guid.NewGuid().ToString();
            this.RoomImages = new HashSet<RoomImages>();
            this.UserRooms = new HashSet<UserRoom>();
        }
        public string Id { get; set; }

        public RoomType RoomType { get; set; }

        public int RoomCount { get; set; }

        public int Adults { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }


        public virtual ICollection<RoomImages> RoomImages { get; set; }

        public virtual ICollection<UserRoom> UserRooms { get; set; }


    }
}
