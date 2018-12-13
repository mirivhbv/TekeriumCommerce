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
        private readonly IRepository<TyreProfile> _profileRepository;
        private readonly IRepository<TyreRimSize> _rimRepository;
        private readonly IRepository<TyreWidthProfileRimSize> _wprRepository;


        public LittleSearchFormViewComponent(IRepository<TyreWidth> widthRepository, IRepository<TyreProfile> profileRepository, IRepository<TyreRimSize> rimRepository, IRepository<TyreWidthProfileRimSize> twrRepository)
        {
            _widthRepository = widthRepository;
            _profileRepository = profileRepository;
            _rimRepository = rimRepository;
            _wprRepository = twrRepository;
        }

        public IViewComponentResult Invoke()
        {
            // 1. get all widths
            // 2. get proper profiles
            // 3. and the rest ajax will do

            string widthQuery = Request.Query["width"];
            string profileQuery = Request.Query["profile"];
            string rimQuery = Request.Query["rimSize"];

            var model = new LittleSearchForm
            {
                AvailableWidths = _widthRepository.Query()
                    .Select(x => new SelectListItem {Value = x.Size, Text = x.Size}).ToList(),
                Width = widthQuery,
                AvailableProfiles = _wprRepository.Query().Where(x => x.TyreWidth.Size == widthQuery).Select(x => x.TyreProfile).Distinct().Select(x => new SelectListItem{ Value = x.Size, Text = x.Size}).ToList(),
                Profile = profileQuery,
                AvailableRimSizes = _wprRepository.Query().Where(x => x.TyreWidth.Size == widthQuery && x.TyreProfile.Size == profileQuery).Select(x => x.TyreRimSize).Distinct().Select(x => new SelectListItem { Value = x.Size, Text = x.Size }).ToList(),
                RimSize = rimQuery
            };

            // var test = Request.Query["width"];

            return View(this.GetViewPath(), model);
        }
    }
}