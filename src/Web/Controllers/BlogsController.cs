using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BlogsController : Controller
    {

        public IActionResult BlogPage()
        {
            return this.View();
        }

        public IActionResult Details()
        {
            return this.View();
        }
    }
}
