using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Images;
using ViewModels.Rooms;
using ViewModels.Users;

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

        public async Task AddRoomToUserAsync(UserReserveFinishViewModel reserveInputModel, string userId, string roomId)
        {
            var wantedRoom = this.db.Rooms.FirstOrDefault(x => x.Id == roomId);
            var wantedUser = this.db.Users.FirstOrDefault(x => x.Id == userId);
            wantedRoom.CheckIn = reserveInputModel.CheckIn;
            wantedRoom.CheckOut = reserveInputModel.CheckOut;
            wantedRoom.RoomCount -= 1;
            wantedUser.PhoneNumber = reserveInputModel.PhoneNumber;
            wantedUser.FirstName = reserveInputModel.FirstName;
            wantedUser.LastName = reserveInputModel.LastName;
            wantedUser.UserRooms.Add(new UserRoom { RoomId = roomId, UserId = userId });
         
            await this.db.SaveChangesAsync();
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

        public IEnumerable<RoomsComponentViewModel> GetComponentRooms()
        {
            return this.db.Rooms.ProjectTo<RoomsComponentViewModel>(this.mapper.ConfigurationProvider)
                                     .ToList();
        }

        public RoomDetailsViewModel GetRoomById(string id)
        {
            return this.db.Rooms.Where(x => x.Id == id)
                                .Select(x => new RoomDetailsViewModel
                                {
                                    Id = x.Id,
                                    Adults = x.Adults,
                                    Description = x.Description,                                                        //TODO: AM
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
