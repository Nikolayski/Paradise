﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Rooms;
using ViewModels.Users;

namespace Services.RoomService
{
    public interface IRoomService
    {
        IEnumerable<RoomsAllViewModel> GetRooms();

        RoomDetailsViewModel GetRoomById(string id);

        IEnumerable<RoomCheckViewModel> CheckRooms(DateTime checkIn, DateTime checkOut, string adults, string roomType);

        RoomsAllViewModel GetSuperiorRoom();

        //Task AddRoomToUserAsync(ReserveRoomViewModel reserveInputModel, string userId);
        Task AddRoomToUserAsync(UserReserveFinishViewModel reserveInputModel, string userId);
    }
}
