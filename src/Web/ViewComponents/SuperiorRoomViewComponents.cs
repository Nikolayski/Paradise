using Services.RoomService;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class SuperiorRoomViewComponents : ViewComponent
    {
        private readonly IRoomService roomsService;

        public SuperiorRoomViewComponents(IRoomService roomsService)
        {
            this.roomsService = roomsService;
        }

        public IViewComponentResult Invoke()
        {
            var superiorRoom = this.roomsService.GetSuperiorRoom();
            return this.View(superiorRoom);
        }
    }
}
