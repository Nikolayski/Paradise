using Services.RoomService;
using Services.UserService;
using ViewModels.Users;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Globalization;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Models.Enums;

namespace Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService roomsService;
        private readonly IUsersService usersService;
         private readonly IMapper imapper;

        public RoomsController(IRoomService roomsService,
                               IUsersService usersService,
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
            var typeOfRoom = this.roomsService.GetTypeOfRoom(id);
            if (typeOfRoom == RoomType.UNKNOWN)
            {
                return this.NotFound();
            }
            this.ViewData["id"] = id;
            this.ViewData["type"] = typeOfRoom;
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Reserve(UserReserveFinishViewModel reserveInputModel, string roomId)
        {
            if (!this.ModelState.IsValid || reserveInputModel.CheckIn < DateTime.UtcNow || reserveInputModel.CheckOut < DateTime.UtcNow)
            {
                this.ViewData["id"] = roomId;
                var typeOfRoom = this.roomsService.GetTypeOfRoom(roomId);
                this.ViewData["type"] = typeOfRoom;
                return this.View(reserveInputModel);
            }
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.roomsService.AddRoomToUserAsync(reserveInputModel, userId, roomId);
            this.TempData["Success"] = "Added Successfully!";
            return this.Redirect($"/Rooms/Details/{roomId}");
        }

        public IActionResult Details(string id)
        {
            var room = this.roomsService.GetRoomById(id);
            if (room == null)
            {
                return this.NotFound();
            }
            return this.View(room);
        }

        public IActionResult Check(string checkIn, string checkOut, string adults, string roomType)
        {
            DateTime checkInDate;
            DateTime checkOutDate;
            bool CancheckInDate = DateTime.TryParseExact(checkIn, "MM/dd/yyyy",CultureInfo.InvariantCulture, DateTimeStyles.None, out checkInDate);
            bool CancheckOutDate = DateTime.TryParseExact(checkOut, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out checkOutDate);

            if (checkInDate > checkOutDate || checkInDate < DateTime.UtcNow || checkOutDate < DateTime.UtcNow)
            {
                return this.Redirect("/");
            }
            var wantedRooms = this.roomsService.CheckRooms(checkInDate, checkOutDate, adults, roomType);
            return this.View(wantedRooms);
        }
    }
}
