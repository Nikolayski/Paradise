using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.SeedService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISeedService seedService;

        public HomeController(ILogger<HomeController> logger, ISeedService seedService)
        {
            _logger = logger;
            this.seedService = seedService;
        }

        public async Task<IActionResult> Index()
        {
            if (!this.seedService.IsPopulate())
            {
               await seedService.AddProductsAsync();
            }
            return this.View();
        }

        public  IActionResult About()
        {
            return this.View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
