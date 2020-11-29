using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Contact()
        {
            return this.View();
        }
    }
}
