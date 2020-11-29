using Models.Enums;
using ViewModels.Images;

using System.Collections.Generic;

namespace ViewModels.Rooms
{
    public  class RoomDetailsViewModel
    {
        public string Id { get; set; }

        public RoomType RoomType { get; set; }

        public string RoomTypeToString => this.RoomType.ToString();

        public int RoomCount { get; set; }

        public int Adults { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public List<ImageUrlViewModel> RoomImages { get; set; }

    }
}
