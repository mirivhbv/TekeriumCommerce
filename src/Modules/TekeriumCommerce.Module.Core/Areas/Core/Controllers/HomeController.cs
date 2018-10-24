using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TekeriumCommerce.Module.Core.Areas.Core.Controllers
{
    [Area("Core")]
    public class HomeController : Controller
    {
        private readonly ILogger logger;

        public HomeController(ILoggerFactory logger)
        {
            this.logger = logger.CreateLogger("Unhandled Error");
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}