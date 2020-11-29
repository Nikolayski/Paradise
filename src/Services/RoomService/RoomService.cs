using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Images;
using ViewModels.Rooms;


namespace Services.RoomService
{
    public  class RoomService : IRoomService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public RoomService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddRoomToUser(ReserveRoomViewModel reserveInputModel, string userId)
        {
            var wantedRoom = this.db.Rooms.FirstOrDefault(x => x.Id == reserveInputModel.RoomId);
            var wantedUser = this.db.Users.FirstOrDefault(x => x.Id == userId);
            wantedRoom.CheckIn = reserveInputModel.CheckIn;
            wantedRoom.CheckOut = reserveInputModel.CheckOut;
            wantedRoom.RoomCount -= 1;
            wantedUser.UserRooms.Add(new UserRoom { RoomId = reserveInputModel.RoomId, UserId = userId });
            this.db.SaveChanges();
        }

        public IEnumerable<RoomCheckViewModel> CheckRooms(DateTime checkIn, DateTime checkOut, string adults, string roomType)
        {
            if (roomType.ToLower() == "all")
            {
                return this.db.Rooms
                           .Where(x => x.Adults >= int.Parse(adults) && x.RoomCount > 0)
                           .ProjectTo<RoomCheckViewModel>(this.mapper.ConfigurationProvider);
            }

            return this.db.Rooms
                          .Where(x => x.RoomType == (RoomType)Enum.Parse(typeof(RoomType), roomType, true) &&
                                                         x.Adults >= int.Parse(adults) &&
                                                         x.RoomCount > 0)
                .ProjectTo<RoomCheckViewModel>(this.mapper.ConfigurationProvider);
        }

        public RoomDetailsViewModel GetRoomById(string id)
        {
            //return this.db.Rooms.Where(x => x.Id == id)
            //           .ProjectTo<RoomDetailsViewModel>(this.mapper.ConfigurationProvider)
            //           .FirstOrDefault();

            return this.db.Rooms.Where(x => x.Id == id)
                                .Select(x => new RoomDetailsViewModel
                                {
                                    Id = x.Id,
                                    Adults = x.Adults,
                                    Description = x.Description,
                                    Image = x.Image,
                                    Price = x.Price,
                                    RoomCount = x.RoomCount,
                                    RoomType = x.RoomType,
                                    RoomImages = x.RoomImages
                                                  .Select(x => new ImageUrlViewModel
                                                  {
                                                      ImageUrl = x.Image.Url
                                                  })
                                                  .ToList()
                                })
                                .FirstOrDefault();
        }

        public IEnumerable<RoomsAllViewModel> GetRooms()
        {
            return this.db.Rooms.OrderBy(x => x.RoomType)
                         .ProjectTo<RoomsAllViewModel>(this.mapper.ConfigurationProvider);
        }

        public RoomsAllViewModel GetSuperiorRoom()
        {
            return this.db.Rooms.Where(x => x.RoomType == RoomType.Superior)
                                .ProjectTo<RoomsAllViewModel>(this.mapper.ConfigurationProvider)
                                .FirstOrDefault();
        }
    }
}
