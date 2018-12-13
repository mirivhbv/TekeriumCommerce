using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Infrastructure.Web;
using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Search.Areas.Search.ViewModels;

namespace TekeriumCommerce.Module.Search.Areas.Search.Components
{
    public class LittleSearchFormViewComponent : ViewComponent
    {
        private readonly IRepository<TyreWidth> _widthRepository;

        public LittleSearchFormViewComponent(IRepository<TyreWidth> widthRepository)
        {
            _widthRepository = widthRepository;
        }

        public IViewComponentResult Invoke()
        {
            // 1. get all widths
            // 2. get proper profiles
            // 3. and the rest ajax will do

            var model = new LittleSearchForm
            {
                AvailableWidths = _widthRepository.Query()
                    .Select(x => new SelectListItem {Value = x.Size, Text = x.Size}).ToList(),
                Width = Request.Query["width"]
            };

            // var test = Request.Query["width"];

            return View(this.GetViewPath(), model);
        }
    }
}