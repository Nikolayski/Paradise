using AutoMapper;
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
using Data;
using System.Linq;

namespace Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService roomsService;
        private readonly IUsersService usersService;
        private readonly ApplicationDbContext db;
        private readonly IMapper imapper;

        public RoomsController(IRoomService roomsService, 
                               IUsersService usersService ,
                               ApplicationDbContext db,
                               IMapper imapper)
        {
            this.roomsService = roomsService;
            this.usersService = usersService;
            this.db = db;
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
            var room = this.db.Rooms.FirstOrDefault(X => X.Id == id);
            var typeOfRoom = room.RoomType;
            this.ViewData["id"] = room.Id;
            this.ViewData["type"] = typeOfRoom;
           return this.View();
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
        public async Task<IActionResult> Reserve(UserReserveFinishViewModel reserveInputModel, string roomId)
        {
            ;
            if (!this.ModelState.IsValid)
            {
                this.ViewData["id"] = roomId;
                var room = this.db.Rooms.FirstOrDefault(X => X.Id == roomId);
                var typeOfRoom = room.RoomType;
                this.ViewData["type"] = typeOfRoom;
                //return this.Redirect($"/Rooms/Details/{reserveInputModel.RoomId}");
                return this.View(reserveInputModel);
            }
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.roomsService.AddRoomToUserAsync(reserveInputModel, userId,roomId);
            return this.Redirect($"/Rooms/Details/{roomId}");
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
