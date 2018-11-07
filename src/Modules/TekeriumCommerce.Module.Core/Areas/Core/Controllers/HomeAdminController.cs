using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TekeriumCommerce.Module.Core.Areas.Core.Controllers
{
    [Area("Core")]
    [Authorize(Roles = "admin")]
    public class HomeAdminController : Controller
    {
        [Route("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}