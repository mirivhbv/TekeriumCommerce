using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TekeriumCommerce.Module.Core.Areas.Core.Controllers
{
    [Area("Core")]
    [Authorize(Roles = "admin")]
    public class DashboardController : Controller
    {
        [Route("admin/dashboard-tpl")]
        public IActionResult HomeTemplate()
        {
            return View();
        }
    }
}