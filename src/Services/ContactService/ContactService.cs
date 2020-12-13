using AutoMapper;
using Data;
using Models;
using System.Threading.Tasks;
using ViewModels.Contacts;

namespace Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ContactService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task AddContactAsync(AddContactViewModel addContactViewModel)
        {
            var contact = this.mapper.Map<Contact>(addContactViewModel);
          await  this.db.Contacts.AddAsync(contact);
          await  this.db.SaveChangesAsync();
        }
    }
}
