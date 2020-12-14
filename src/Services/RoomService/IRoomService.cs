using ViewModels.Rooms;
using ViewModels.Users;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Enums;

namespace Services.RoomService
{
    public interface IRoomService
    {
        IEnumerable<RoomsAllViewModel> GetRooms();

        RoomDetailsViewModel GetRoomById(string id);

        IEnumerable<RoomCheckViewModel> CheckRooms(DateTime checkIn, DateTime checkOut, string adults, string roomType);

        RoomsAllViewModel GetSuperiorRoom();

        IEnumerable<RoomsComponentViewModel> GetComponentRooms();

        Task AddRoomToUserAsync(UserReserveFinishViewModel reserveInputModel, string userId, string roomId);

        RoomType GetTypeOfRoom(string id);
    }
}
