using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Search.Areas.Search.ViewModels;

namespace TekeriumCommerce.Module.Search.Areas.Search.Controllers
{
    [Area("search")]
    public class SearchApiController : Controller
    {
        private readonly IRepository<TyreWidth> _tyreWidthRepository;
        private readonly IRepository<TyreRimSize> _tyreRimSizeRepository;

        public SearchApiController(IRepository<TyreWidth> tyreWidthRepository, IRepository<TyreRimSize> tyreRimSizeRepository)
        {
            _tyreWidthRepository = tyreWidthRepository;
            _tyreRimSizeRepository = tyreRimSizeRepository;
        }

        [HttpPost]
        public IActionResult SelectWidth([FromBody] SearchCriteria searchCriteria)
        {
            List<TyreWidth> list = null;

            list = _tyreWidthRepository.Query().Where(x => x.Size == searchCriteria.Width)
                .Include(x => x.TyreWidthProfileRimSizes).ThenInclude(x => x.TyreProfile).ToList();

            var g = (from c in list
                from m in c.TyreWidthProfileRimSizes
                select m.TyreProfile).Distinct().Select(x => x.Size);

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(g);
        }

        [HttpPost]
        public IActionResult SelectProfile([FromBody] SearchCriteria searchCriteria)
        {
            List<TyreRimSize> listRimSizes = null;

            listRimSizes = this._tyreRimSizeRepository.Query()
                .Include(x => x.TyreWidthProfileRimSizes).ThenInclude(a => a.TyreProfile)
                .Include(x => x.TyreWidthProfileRimSizes).ThenInclude(a => a.TyreWidth).ToList();

            var g = (from c in listRimSizes
                from m in c.TyreWidthProfileRimSizes
                where m.TyreProfile.Size == searchCriteria.Profile && m.TyreWidth.Size == searchCriteria.Width
                select m.TyreRimSize).Distinct().Select(x => x.Size);

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(g);
        }
    }
}