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
        private readonly IRepository<Category> _categoryRepository;

        public SearchFormViewComponent(IRepository<TyreWidth> widthRepository, IRepository<Category> categoryRepository)
        {
            _widthRepository = widthRepository;
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var model = new SearchForm
            {
                AvailableWidths = _widthRepository.Query()
                    .Select(x => new SelectListItem { Value = x.Size, Text = x.Size }).ToList(),
                // Width = Request.Query["width"] // todo: search about that (what is it)
                CarActive = _categoryRepository.Query().SingleOrDefault(x => x.Name == "Car").IncludeInMenu,
                LCVActive = _categoryRepository.Query().SingleOrDefault(x => x.Name == "Light Commercial Vehicle")?.IncludeInMenu,
                TruckActive = _categoryRepository.Query().SingleOrDefault(x => x.Name == "Truck")?.IncludeInMenu,
                TractorActive = _categoryRepository.Query().SingleOrDefault(x => x.Name == "Tractor")?.IncludeInMenu
            };

            return View(this.GetViewPath(), model);
        }
    }
}