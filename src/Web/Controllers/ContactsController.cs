using ViewModels.Contacts;

using Microsoft.AspNetCore.Mvc;

using Services.ContactService;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService contactService;

        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        public IActionResult Contact()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(AddContactViewModel addContactViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(addContactViewModel);
            }
            await this.contactService.AddContactAsync(addContactViewModel);
            this.TempData["Success"] = "Added Successfully!";
            return this.View();
        }
    }
}

