using System;
using System.Collections.Generic;

using ViewModels.Rooms;

namespace Services.RoomService
{
    public interface IRoomService
    {
        IEnumerable<RoomsAllViewModel> GetRooms();

        RoomDetailsViewModel GetRoomById(string id);

        IEnumerable<RoomCheckViewModel> CheckRooms(DateTime checkIn, DateTime checkOut, string adults, string roomType);

        RoomsAllViewModel GetSuperiorRoom();

        void AddRoomToUser(ReserveRoomViewModel reserveInputModel, string userId);
    }
}
