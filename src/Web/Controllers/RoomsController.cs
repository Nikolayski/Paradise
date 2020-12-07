﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Security.Claims;

using Services.RoomService;
using ViewModels.Rooms;
using System.Threading.Tasks;
using Services.UserService;
using ViewModels.Users;

namespace Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService roomsService;
        private readonly IUsersService usersService;
        private readonly IMapper imapper;

        public RoomsController(IRoomService roomsService, 
                               IUsersService usersService ,
                               IMapper imapper)
        {
            this.roomsService = roomsService;
            this.usersService = usersService;
            this.imapper = imapper;
        }

        public IActionResult OurRooms()
        {
            var rooms = this.roomsService.GetRooms();
            return this.View(rooms);
        }

        [Authorize]
        public IActionResult Reserve(string id)
        {
            
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = this.usersService.GetUser(userId);
            user.RoomId = id;
             return this.View(user);
        }

        [Authorize]
        //[HttpPost]
        //public async Task<IActionResult> Reserve(ReserveRoomViewModel reserveInputModel)
        //{
        //    ;
        //    if (!this.ModelState.IsValid)
        //    {
        //       return this.Redirect($"/Rooms/Details/{reserveInputModel.RoomId}");
        //    }
        //    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //   await this.roomsService.AddRoomToUserAsync(reserveInputModel, userId);
        //    ;
        //    return this.Redirect($"/Rooms/Details/{reserveInputModel.RoomId}");
        //}

        [HttpPost]
        public async Task<IActionResult> Reserve(UserReserveFinishViewModel reserveInputModel)
        {
            ;
            if (!this.ModelState.IsValid)
            {
                return this.Redirect($"/Rooms/Details/{reserveInputModel.RoomId}");
            }
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.roomsService.AddRoomToUserAsync(reserveInputModel, userId);
            return this.Redirect($"/Rooms/Details/{reserveInputModel.RoomId}");
        }
        public IActionResult Details(string id)
        {
            var room = this.roomsService.GetRoomById(id);
            ;
            return this.View(room);
        }

      public IActionResult Check(string checkIn, string checkOut, string adults, string roomType)
        {
           DateTime checkInDate;
            DateTime checkOutDate;
            bool CancheckInDate = DateTime.TryParseExact(checkIn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out checkInDate);
            bool CancheckOutDate = DateTime.TryParseExact(checkOut, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out checkOutDate);

            if (checkInDate > checkOutDate)
            {

                return this.Redirect("/");
            }
            var wantedRooms = this.roomsService.CheckRooms(checkInDate, checkOutDate, adults, roomType);
           return this.View(wantedRooms);

        }
    }
}
