using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Catalog.Areas.Catalog.Controllers;
using TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Core.Services;
using TekeriumCommerce.Module.Search.Areas.Search.ViewModels;

namespace TekeriumCommerce.Module.Search.Areas.Search.Controllers
{
    public class SearchController : Controller
    {
        private readonly int _pageSize;

        private readonly IRepository<TyreWidth> _tyreWidthRepository;
        private readonly IRepository<TyreRimSize> _tyreRimSizeRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IMediaService _mediaService;

        public SearchController(IRepository<TyreWidth> tyreWidthRepository,
                IRepository<TyreRimSize> tyreRimSizeRepository,
                IRepository<Product> productRepository,
                IMediaService mediaService,
                IConfiguration config)
        {
            _tyreWidthRepository = tyreWidthRepository;
            _tyreRimSizeRepository = tyreRimSizeRepository;
            _productRepository = productRepository;
            _mediaService = mediaService;
            _pageSize = config.GetValue<int>("Catalog.ProductPageSize");
        }

        public IActionResult Index(SearchOption searchOption)
        {
            if (string.IsNullOrWhiteSpace(searchOption.Width) || string.IsNullOrWhiteSpace(searchOption.Profile) ||
                string.IsNullOrWhiteSpace(searchOption.RimSize))
            {
                return Redirect("~/");
            }

            var model = new SearchResult
            {
                CurrentSearchOption = searchOption
            };

            var query = _productRepository.Query().Where(x =>
                x.TyreWidth.Size == searchOption.Width && x.TyreProfile.Size == searchOption.Profile &&
                x.TyreRimSize.Size == searchOption.RimSize && x.IsPublished);

            if (!query.Any())
            {
                model.TotalProduct = 0;
                return View(model);
            }

            model.TotalProduct = query.Count();

            var currentPageNum = searchOption.Page <= 0 ? 1 : searchOption.Page;

            var offset = (_pageSize * currentPageNum) - _pageSize;

            while (currentPageNum > 1 && offset > model.TotalProduct)
            {
                currentPageNum--;
                offset = (_pageSize * currentPageNum) - _pageSize;
            }

            // todo: save query (search) to db

            query = query.Include(x => x.ThumbnailImage);

            var products = query
                .Select(x => ProductThumbnail.FromProduct(x))
                .Skip(offset)
                .Take(_pageSize)
                .ToList();

            foreach (var product in products)
            {
                product.ThumbnailUrl = _mediaService.getThumbnailUrl(product.ThumbnailImage);
            }

            model.Products = products;
            model.CurrentSearchOption.PageSize = _pageSize;
            model.CurrentSearchOption.Page = currentPageNum;

            return View(model);
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