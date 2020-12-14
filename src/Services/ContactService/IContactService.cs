using ViewModels.Contacts;

using System.Threading.Tasks;

namespace Services.ContactService
{
    public interface IContactService
    {
       Task AddContactAsync(AddContactViewModel addContactViewModel);
    }
}
