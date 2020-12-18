using AutoMapper;
using Data;
using Mapping;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Services.RoomService;
using System;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Users;
using Xunit;

namespace Tests
{
    public class RoomServiceTests
    {
        [Fact]
        public async Task AddRoomToUserAsyncShouldAddRowInUsersRoomTable()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var roomService = new RoomService(db, mapper);

            //Act
            var user = new ApplicationUser
            {
                UserName = "niko@abv.bg",
                Email = "niko@abv.bg"
            };
            var room = new Room
            {
                Adults = 1,
                CheckIn = new DateTime(2020, 12, 20),
                CheckOut = new DateTime(2020, 12, 21),
                Image = "no image",
                Description = "no description",
                Price = 5,
                RoomCount = 5,
                RoomType = RoomType.Single,
            };
            db.Rooms.Add(room);
            db.Users.Add(user);
            await db.SaveChangesAsync();

            var viewModel = new UserReserveFinishViewModel
            {
                CheckIn = new DateTime(2020, 12, 20),
                CheckOut = new DateTime(2020, 12, 20),
                CreaditCardNumber = "1234512345123451",
                Cvv = 111,
                Expiration = "03/24",
                FirstName = "Gosho",
                LastName = "Goshev",
                NameOfCard = "Gosho Goshev",
                PhoneNumber = "1231231231",
            };
            await roomService.AddRoomToUserAsync(viewModel, user.Id, room.Id);

            //assert
            Assert.True(await db.UserRooms.CountAsync() == 1);
        }

        [Fact]
        public async Task CheckRoomsShouldWorkCorrectlyIfTypeOfRoomIsDifferenFromAll()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var roomService = new RoomService(db, mapper);

            //Act
            var room = new Room
            {
                Adults = 1,
                CheckIn = new DateTime(2020, 12, 20),
                CheckOut = new DateTime(2020, 12, 21),
                Image = "no image",
                Description = "no description",
                Price = 5,
                RoomCount = 5,
                RoomType = RoomType.Single,
            };
            var room2 = new Room
            {
                Adults = 2,
                CheckIn = new DateTime(2020, 12, 22),
                CheckOut = new DateTime(2020, 12, 23),
                Image = "no image2",
                Description = "no description2",
                Price = 6,
                RoomCount = 6,
                RoomType = RoomType.Double,
            };
            var room3 = new Room
            {
                Adults = 3,
                CheckIn = new DateTime(2020, 12, 25),
                CheckOut = new DateTime(2020, 12, 26),
                Image = "no image3",
                Description = "no description3",
                Price = 6,
                RoomCount = 6,
                RoomType = RoomType.Double,
            };
            db.Rooms.Add(room);
            db.Rooms.Add(room2);
            db.Rooms.Add(room3);
            await db.SaveChangesAsync();

            var models = roomService.CheckRooms(new DateTime(2020, 12, 22), new DateTime(2020, 12, 24), "1", "Double");

            //assert
            Assert.True(models.Count() == 2);
        }

        [Fact]
        public async Task CheckRoomsShouldWorkCorrectlyIfTypeOfRoomIsAll()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var roomService = new RoomService(db, mapper);

            //Act
            var room = new Room
            {
                Adults = 1,
                CheckIn = new DateTime(2020, 12, 20),
                CheckOut = new DateTime(2020, 12, 21),
                Image = "no image",
                Description = "no description",
                Price = 5,
                RoomCount = 5,
                RoomType = RoomType.Single,
            };
            db.Rooms.Add(room);
            await db.SaveChangesAsync();

            var models = roomService.CheckRooms(new DateTime(2020, 12, 22), new DateTime(2020, 12, 24), "1", "All");

            //assert
            Assert.True(models.Count() == 1);
        }

        [Fact]
        public async Task GetComponentRoomsShouldReturnValidData()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var roomService = new RoomService(db, mapper);

            //Act
            var room = new Room
            {
                Adults = 1,
                CheckIn = new DateTime(2020, 12, 20),
                CheckOut = new DateTime(2020, 12, 21),
                Image = "no image",
                Description = "no description",
                Price = 5,
                RoomCount = 5,
                RoomType = RoomType.Single,
            };
            var room2 = new Room
            {
                Adults = 1,
                CheckIn = new DateTime(2020, 12, 24),
                CheckOut = new DateTime(2020, 12, 25),
                Image = "no image2",
                Description = "no description2",
                Price = 5,
                RoomCount = 5,
                RoomType = RoomType.Double,
            };
            db.Rooms.Add(room);
            db.Rooms.Add(room2);
            await db.SaveChangesAsync();
            var models = roomService.GetComponentRooms();

            //asert
            Assert.True(models.Count() == 2);
        }
        [Fact]
        public async Task GetRoomByIdShouldReturnValidRoom()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var roomService = new RoomService(db, mapper);

            //Act
            var room = new Room
            {
                Adults = 1,
                CheckIn = new DateTime(2020, 12, 20),
                CheckOut = new DateTime(2020, 12, 21),
                Image = "no image",
                Description = "no description",
                Price = 5,
                RoomCount = 5,
                RoomType = RoomType.Single,
            };
            db.Rooms.Add(room);
            await db.SaveChangesAsync();
            var wantedRoom = roomService.GetRoomById(room.Id);

            //Assert
            Assert.Equal(wantedRoom.Id, room.Id);
        }
        [Fact]
        public async Task GetRoomsShouldReturnAllValidRooms()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var roomService = new RoomService(db, mapper);

            //Act
            var room = new Room
            {
                Adults = 1,
                CheckIn = new DateTime(2020, 12, 20),
                CheckOut = new DateTime(2020, 12, 21),
                Image = "no image",
                Description = "no description",
                Price = 5,
                RoomCount = 5,
                RoomType = RoomType.Single,
            };
            var room2 = new Room
            {
                Adults = 2,
                CheckIn = new DateTime(2020, 12, 23),
                CheckOut = new DateTime(2020, 12, 24),
                Image = "no image4",
                Description = "no description4",
                Price = 5,
                RoomCount = 5,
                RoomType = RoomType.Single,
            };
            db.Rooms.Add(room);
            db.Rooms.Add(room2);
            await db.SaveChangesAsync();
            var models = roomService.GetRooms();

            //assert
            Assert.True(models.Count() == 2);
        }
        [Fact]
        public async Task GetSuperiorRoomShouldWorkCorrectly()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var roomService = new RoomService(db, mapper);

            //Act
            var room = new Room
            {
                Adults = 1,
                CheckIn = new DateTime(2020, 12, 20),
                CheckOut = new DateTime(2020, 12, 21),
                Image = "no image",
                Description = "no description",
                Price = 5,
                RoomCount = 5,
                RoomType = RoomType.Superior,
            };
            db.Rooms.Add(room);
            await db.SaveChangesAsync();
            var superiorRoom = roomService.GetSuperiorRoom();

            //assert
            Assert.Equal(superiorRoom.Id, room.Id);
        }

        [Fact]
        public async Task GetTypeOfRoomShouldReturnTheValidTypeOfWantedRoom()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var roomService = new RoomService(db, mapper);

            //Act
            var room = new Room
            {
                Adults = 1,
                CheckIn = new DateTime(2020, 12, 20),
                CheckOut = new DateTime(2020, 12, 21),
                Image = "no image",
                Description = "no description",
                Price = 5,
                RoomCount = 5,
                RoomType = RoomType.Superior,
            };
            db.Rooms.Add(room);
            await db.SaveChangesAsync();
            var typeOfRoom = roomService.GetTypeOfRoom(room.Id);

            Assert.True(typeOfRoom == RoomType.Superior);
        }
    }
}
