using Microsoft.AspNetCore.Mvc;
using Services.RoomService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents
{
    public class RoomsViewComponent : ViewComponent
    {
        private readonly IRoomService roomService;

        public RoomsViewComponent(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        public IViewComponentResult Invoke()
        {
            var rooms = this.roomService.GetComponentRooms();
            return this.View(rooms);
        }
    }
}
