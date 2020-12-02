using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Rooms
{
    public  class ReserveRoomViewModel
    {
        public string RoomId { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,}$")]
        public string PhoneNumber { get; set; }

    }
}
