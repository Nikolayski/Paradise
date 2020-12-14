using Data;
using Models;
using ViewModels.Contacts;

using AutoMapper;

using System.Threading.Tasks;

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
            await this.db.Contacts.AddAsync(contact);
            await this.db.SaveChangesAsync();
        }
    }
}
