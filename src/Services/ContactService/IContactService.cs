using System.Threading.Tasks;
using ViewModels.Contacts;

namespace Services.ContactService
{
    public interface IContactService
    {
        Task AddContactAsync(AddContactViewModel addContactViewModel);
    }
}
