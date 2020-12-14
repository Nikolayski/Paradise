using Services.RoomService;

using Microsoft.AspNetCore.Mvc;

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
