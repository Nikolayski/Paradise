using AutoMapper;
using Data;
using Mapping;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Comments;
using Services.ContactService;
using System;
using System.Threading.Tasks;
using ViewModels.Contacts;
using Xunit;

namespace Tests
{
    public class ContactServiceTests
    {
        [Fact]
        public async Task AddContactAsyncShouldWorkProperly()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var contactService = new ContactService(db, mapper);

            var model = new AddContactViewModel
            {
                Email = "nnnnnnnn@gmail.com",
                Message = "Hello world!",
                Name = "Niko",
                Subject = "Hi"
            };
            await contactService.AddContactAsync(model);

            //assert
            Assert.True(await db.Contacts.CountAsync() == 1);
        }
    }
}
