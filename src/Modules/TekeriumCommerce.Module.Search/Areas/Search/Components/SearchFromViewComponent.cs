using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Infrastructure.Web;
using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Search.Areas.Search.ViewModels;

namespace TekeriumCommerce.Module.Search.Areas.Search.Components
{
    public class SearchFormViewComponent : ViewComponent
    {
        private readonly IRepository<TyreWidth> _widthRepository;

        public SearchFormViewComponent(IRepository<TyreWidth> widthRepository)
        {
            _widthRepository = widthRepository;
        }

        public IViewComponentResult Invoke()
        {
            var model = new SearchForm
            {
                AvailableWidths = _widthRepository.Query()
                    .Select(x => new SelectListItem { Value = x.Size, Text = x.Size }).ToList(),
                Width = Request.Query["width"]
            };

            return View(this.GetViewPath(), model);
        }
    }
}